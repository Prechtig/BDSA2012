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
        /// Create a task
        /// </summary>
        /// <param name="task">The task to create</param>
        /// <returns>Wether or not the call was successful</returns>
        public void CreateTask(Task task)
        {
            if (domain.CreateTask(task))
            {
                view.UpdateCalendar();
            }
            else
            {
                view.ShowError(new Error("Create Task Error"));
            }
        }

        /// <summary>
        /// Invoked when a user clicks on a task
        /// </summary>
        public void GetTask(uint id)
        {
            view.DisplayTask(domain.GetTask(id));
        }

        /// <summary>
        /// Invoked when a user want's to see tasks for a given interval
        /// </summary>
        /// <param name="startDate">The StartDate</param>
        /// <param name="endDate">The EndDate</param>
        private void DisplayTasks(DateTime startDate, DateTime endDate)
        {
            List<Task> list = domain.GetTasks(startDate, endDate);
            view.DisplayTasks(list);
        }

        public static Controller GetController()
        {
            if (controller == null) { controller = new Controller(); }
            return controller;
        }
    }
}