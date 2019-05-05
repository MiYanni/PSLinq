namespace Sample.API.Models
{
    using static Sample.API.Runtime.Extensions;
    public partial class Comic : Sample.API.Models.IComic
    {
        /// <summary>Backing field for <see cref="Alt" /> property.</summary>
        private string _alt;

        public string Alt { get => this._alt; set => this._alt = value; }
        /// <summary>Backing field for <see cref="Day" /> property.</summary>
        private string _day;

        public string Day { get => this._day; set => this._day = value; }
        /// <summary>Backing field for <see cref="Img" /> property.</summary>
        private string _img;

        public string Img { get => this._img; set => this._img = value; }
        /// <summary>Backing field for <see cref="Link" /> property.</summary>
        private string _link;

        public string Link { get => this._link; set => this._link = value; }
        /// <summary>Backing field for <see cref="Month" /> property.</summary>
        private string _month;

        public string Month { get => this._month; set => this._month = value; }
        /// <summary>Backing field for <see cref="News" /> property.</summary>
        private string _news;

        public string News { get => this._news; set => this._news = value; }
        /// <summary>Backing field for <see cref="Num" /> property.</summary>
        private float? _num;

        public float? Num { get => this._num; set => this._num = value; }
        /// <summary>Backing field for <see cref="SafeTitle" /> property.</summary>
        private string _safeTitle;

        public string SafeTitle { get => this._safeTitle; set => this._safeTitle = value; }
        /// <summary>Backing field for <see cref="Title" /> property.</summary>
        private string _title;

        public string Title { get => this._title; set => this._title = value; }
        /// <summary>Backing field for <see cref="Transcript" /> property.</summary>
        private string _transcript;

        public string Transcript { get => this._transcript; set => this._transcript = value; }
        /// <summary>Backing field for <see cref="Year" /> property.</summary>
        private string _year;

        public string Year { get => this._year; set => this._year = value; }
        /// <summary>Creates an new <see cref="Comic" /> instance.</summary>
        public Comic()
        {
        }
    }
    public partial interface IComic : Sample.API.Runtime.IJsonSerializable {
        string Alt { get; set; }
        string Day { get; set; }
        string Img { get; set; }
        string Link { get; set; }
        string Month { get; set; }
        string News { get; set; }
        float? Num { get; set; }
        string SafeTitle { get; set; }
        string Title { get; set; }
        string Transcript { get; set; }
        string Year { get; set; }
    }
}