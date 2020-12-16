using System;
using System.Collections.Generic;

namespace Proyecto
{
    public class AllItems
    {
        public List<AbstractItem> ItemList;
        private static AllItems instance;
        private AllItems()
        {
            this.ItemList = new List<AbstractItem>();
        }
        public static AllItems Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AllItems();
                }

                return instance;
            }
        }
        public AbstractItem GetItem(String itemName)
        {
            foreach (AbstractItem item in this.ItemList)
            {
                if(item.Name == itemName)
                {
                    return item;
                }
            }
            return AbstractItem.Empty;//Se debe dar una excepcion
        }
        public AbstractItem GetItem(AbstractItem itemName)
        {
            foreach (AbstractItem item in this.ItemList)
            {
                if(item == itemName)
                {
                    return item;
                }
            }
            return AbstractItem.Empty;//Se debe dar una excepcion
        }
    }
}