using System;
using System.Collections.Generic;
using UI;
using Model;
using Assignment39;

namespace Controller
{
    class Controller
    {
        private View view;
        private Domain domain;
        private static Controller controller;

        private Controller()
        {
            view = new View();
            domain = new Domain();
            Start();
        }

        /// <summary>
        /// Start the the program.
        /// </summary>
        private void Start()
        {

        }

        /// <summary>
        /// Invoked when a user clicks on a task
        /// </summary>
        private void DisplayTask(uint id)
        {
            Task task = domain.GetTask(id);
            view.DisplayTask(task);
        }

        /// <summary>
        /// Invoked when a user want's to see tasks for a given interval
        /// </summary>
        /// <param name="startDate">The StartDate</param>
        /// <param name="endDate">The EndDate</param>
        private void DisplayTasks(DateTime startDate, DateTime endDate)
        {
            List<Task> list = domain.GetTasks(startDate, endDate);
            view.DisplayMonth(list);
        }

        public static Controller GetController()
        {
            if (controller == null) { controller = new Controller(); }
            return controller;
        }
    }
}