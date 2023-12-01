using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface ISaleOrderLineServices
    {
        public SaleOrderLine? GetSaleOrderLine(int id);
        public int AddSaleOrderLine(SaleOrderLine saleOrderLine);
    }
}
