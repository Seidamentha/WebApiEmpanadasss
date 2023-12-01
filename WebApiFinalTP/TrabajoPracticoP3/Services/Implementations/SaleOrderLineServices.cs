using Microsoft.EntityFrameworkCore;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.DBContext;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Services.Implementations
{
    public class SaleOrderLineServices : ISaleOrderLineServices
    {
        private readonly ECommerceContext _context;

        public SaleOrderLineServices(ECommerceContext context)
        {
            _context = context;
        }

        public SaleOrderLine? GetSaleOrderLine(int id)
        {
            return _context.SaleOrderLines
                .Include(s => s.Product)
                .SingleOrDefault(s => s.Id == id);
        }

        public int AddSaleOrderLine(SaleOrderLine saleOrderLine)
        {
            _context.Add(saleOrderLine);
            _context.SaveChanges();

            return saleOrderLine.Id;
        }
    }
}
