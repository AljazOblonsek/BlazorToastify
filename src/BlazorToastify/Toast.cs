using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorToastify
{
    public class Toast
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; } = "default";
        public string Animation { get; set; } = "bounce";
        public string Message { get; set; }
        public int AutoClose { get; set; } = 3000;
        public bool Visible { get; set; } = true;
        public bool EnterAnimation { get; set; } = true;
        public bool ExitAnimation { get; set; } = false;

        public Toast() { }

        public Toast(string type, string animation, string message, int autoClose)
        {
            Type = type;
            Animation = animation;
            Message = message;
            AutoClose = autoClose;
        }
    }
}
