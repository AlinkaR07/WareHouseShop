using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        TovarView GetTovar(int cod);
        TovarView GetTovar(string name);
        OrderView GetOrder(int cod);
        List<TovarView> GetAllTovar();
        List<LineOrderView> GetAllLineOrder();
        List<PostavshikView> GetAllPostavshiki();
        List<OrderView> GetAllOrder();
        List<WriteView> GetAllWrite();
        List<CategoriesView> GetAllCategories();
        void CreateTovar(TovarView t);
        void CreatePostavshik(PostavshikView p);
        void CreateOrder(OrderView o);
        void CreateLineOrder(LineOrderView lo);
        void CreateWrite(WriteView w);
        void CreateLineWrite(LineWriteView lw);
        void UpdateTovar(TovarView t);
        void UpdatePostavshik(PostavshikView p);
        void UpdateOrder(OrderView o);
        void UpdateLineOrder(LineOrderView lo);
        void UpdateWrite(WriteView w);
        void UpdateLineWrite(LineWriteView lw);
        void DeleteTovar(int cod);
        void DeleteOrder(int cod);
        void DeleteLineOrder(int cod);
        void DeletePostavshik(string cod);
        void DeleteWrite(int cod);
        void DeleteLineWrite(int cod);
        bool Save();
    }
}
