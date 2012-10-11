using System;
using System.Collections.Generic;
using Assignment39;

namespace Model
{
    class Domain
    {
        private DataAccesObject dao;
        
        public Domain()
        {
            dao = new DataAccesObject();
        }

        public bool CreateTask(Task task)
        {
            return dao.CreateTask(task);
        }

        public Task GetTask(uint id)
        {
            return dao.GetTask(id);
        }

        public List<Task> GetTasks(DateTime startDate, DateTime endDate)
        {
            return dao.GetTasks(startDate, endDate);
        }
    }
}
