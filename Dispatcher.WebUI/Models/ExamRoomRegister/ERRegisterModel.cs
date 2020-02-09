namespace Dispatcher.WebUI.Models.ExamRoomRegister
{
    using System;
    using Shared;

    public class ERRegisterModel : RegisterModel
    {
        public int[] GroupIds { get; set; }
        public DateTime ExamDate { get; set; }
        public int[] SupervisiorIds { get; set; }
    }
}