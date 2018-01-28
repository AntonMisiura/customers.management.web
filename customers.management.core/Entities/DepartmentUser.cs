using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Contracts;

namespace customers.management.core.Entities
{
    public class DepartmentUser : IEntity, IEnumerable
    {
        public int? Id { get; set; }
        
        public int DepartmentId { get; set; }
        public int UserId { get; set; }

        public bool IsManager { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
