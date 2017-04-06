using Shared.Interfaces;
using System;

namespace AgentsUi.ViewModel
{
    public class DateTab : Tab
    {
        public DateTab()
        {
            Name = DateTime.Now.ToString();
        }
    }
}