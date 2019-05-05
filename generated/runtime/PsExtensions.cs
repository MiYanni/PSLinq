﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Automation;
using System.Reflection;

namespace Sample.API.Runtime.PowerShell
{
    internal static class PsExtensions
    {
        // https://stackoverflow.com/a/863944/294804
        // https://stackoverflow.com/a/4452598/294804
        // https://stackoverflow.com/a/28701974/294804
        // Note: This will unwrap nested collections, but we don't generate nested collections.
        public static Type Unwrap(this Type type)
        {
            if (type.IsArray)
            {
                return type.GetElementType().Unwrap();
            }

            var typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType
                && (typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>) || typeof(IEnumerable<>).IsAssignableFrom(type)))
            {
                return typeInfo.GetGenericArguments().First().Unwrap();
            }

            return type;
        }

        // https://stackoverflow.com/a/863944/294804
        private static bool IsSimple(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsPrimitive
                   || typeInfo.IsEnum
                   || type == typeof(string)
                   || type == typeof(decimal);
        }

        // https://stackoverflow.com/a/32025393/294804
        private static bool HasImplicitConversion(this Type baseType, Type targetType) =>
            baseType.GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(mi => mi.Name == "op_Implicit" && mi.ReturnType == targetType)
                .Any(mi => mi.GetParameters().FirstOrDefault()?.ParameterType == baseType);

        public static bool IsPsSimple(this Type type)
        {
            var unwrappedType = type.Unwrap();
            return unwrappedType.IsSimple()
                   || unwrappedType == typeof(SwitchParameter)
                   || unwrappedType == typeof(Hashtable)
                   || unwrappedType == typeof(PSCredential)
                   || unwrappedType == typeof(ScriptBlock)
                   || unwrappedType == typeof(DateTime)
                   || unwrappedType == typeof(Uri)
                   || unwrappedType.HasImplicitConversion(typeof(string));
        }

        public static string ToPsList(this IEnumerable<string> items) => String.Join(", ", items.Select(i => $"'{i}'"));

        public static IEnumerable<string> ToAliasNames(this IEnumerable<Attribute> attributes) => attributes.OfType<AliasAttribute>().SelectMany(aa => aa.AliasNames).Distinct();

        public static IEnumerable<T> RunScript<T>(this PSCmdlet cmdlet, string script)
            => PsHelpers.RunScript<T>(cmdlet.InvokeCommand, script);

        public static void RunScript(this PSCmdlet cmdlet, string script)
            => cmdlet.RunScript<PSObject>(script);

        public static IEnumerable<T> RunScript<T>(this EngineIntrinsics engineIntrinsics, string script)
            => PsHelpers.RunScript<T>(engineIntrinsics.InvokeCommand, script);

        public static void RunScript(this EngineIntrinsics engineIntrinsics, string script)
            => engineIntrinsics.RunScript<PSObject>(script);

        public static IEnumerable<T> RunScript<T>(this PSCmdlet cmdlet, ScriptBlock block)
            => PsHelpers.RunScript<T>(cmdlet.InvokeCommand, block.ToString());

        public static void RunScript(this PSCmdlet cmdlet, ScriptBlock block)
            => cmdlet.RunScript<PSObject>(block.ToString());

        public static IEnumerable<T> RunScript<T>(this EngineIntrinsics engineIntrinsics, ScriptBlock block)
            => PsHelpers.RunScript<T>(engineIntrinsics.InvokeCommand, block.ToString());

        public static void RunScript(this EngineIntrinsics engineIntrinsics, ScriptBlock block)
            => engineIntrinsics.RunScript<PSObject>(block.ToString());

        public static bool IsParameterBound<TPSCmdlet, TProp>(this TPSCmdlet cmdlet, Expression<Func<TPSCmdlet, TProp>> propertySelector) where TPSCmdlet : PSCmdlet
            => cmdlet.MyInvocation.BoundParameters.ContainsKey(((MemberExpression)propertySelector.Body).Member.Name);
    }
}
