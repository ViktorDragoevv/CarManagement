using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomnaCarProject
{
    public class ClassDocumentDetails
    {
        
        public string userConsumable { get; set; }
        public decimal quantity { get; set; }
        public decimal bruto { get; set; }
        public decimal neto { get; set; }

        public int consumable { get; set; }

        public int id { get; set; }
        public int editnumber { get; set; }
        public ClassDocumentDetails() { }
        public ClassDocumentDetails(int id ,decimal bruto ,decimal neto , int consumable ,int quantity)
        {
            this.id = id;
            this.bruto = bruto;
            this.neto = neto;
            this.consumable = consumable;
            this.quantity = quantity;
        }
        public bool isValidData(ClassDocumentDetails doc)
        {
            bool flag = true;

            if(doc.bruto==0|| doc.consumable==0 || doc.neto == 0 || doc.quantity == 0)
            {
                flag = false;
            }

            return flag;
        }
        public bool isDocumentInDatabase(ClassDocumentDetails doc)
        {
            bool flag = true;
            if (doc.id==0)
            {
                flag = false;
            }
            return flag;
        }

    }
}
