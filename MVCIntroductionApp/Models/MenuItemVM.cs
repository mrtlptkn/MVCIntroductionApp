namespace MVCIntroductionApp.Models
{
    public class MenuItemVM
    {
        public MenuItemVM(string title, string controller, string action)
        {
            Title = title;
            Controller = controller;
            Action = action;
        }

        public string Title { get; }

        public string Controller { get; }

        public string Action { get; }
    }
}
