using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customers.management.impl.EF.Services
{
    public class TypeInitializer
    {
        private readonly CustomersContext _context;

        public TypeInitializer(CustomersContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.Types.Any())
            {
                _context.AddRange(_types);
                await _context.SaveChangesAsync();
            }
        }

        private readonly List<core.Entities.Type> _types = new List<core.Entities.Type>
        {
            new core.Entities.Type()
            {
                Id = 1,
                Name = "Municipality"
            },
            new core.Entities.Type()
            {
                Id = 2,
                Name = "Business"
            }
        };
    }
}
