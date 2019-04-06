using System;

namespace LP.ApplicationService.ViewModels
{
    public class UserViewModel : BaseViewModel
    {        
        public string Name { get; set; }
        public string Login { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
