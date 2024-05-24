using OHAHA.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OHAHA
{
    class DatabaseOperation
    {
        private readonly MaltoEntities _context = new MaltoEntities();
        private readonly BindingSource _bindingSource;
       
        
        public DatabaseOperation() { }

        public DatabaseOperation(BindingSource _bindingSource)
        {
            this._bindingSource = _bindingSource;
        }

        public MaltoEntities _con
        {
            get
            {
                return _context;
            }
        }

        public void addClient()
        {
            AddClient _addClient = new AddClient();
            _addClient.ShowDialog();

            string fname = _addClient.GetAddText[0];
            string lname = _addClient.GetAddText[1];
            string residency = _addClient.GetAddText[2];
            DateTime date = _addClient.dateValue;


            CLIENT addClient = new CLIENT();

            addClient.FirstName = fname;
            addClient.Lastname = lname;
            addClient.Residency = residency;
            addClient.Birthday = date;

            _context.CLIENTs.Add(addClient);
            _context.SaveChanges();

            _bindingSource.DataSource = _context.CLIENTs.ToList();
        }

        public void updateClient(int _id)
        {
            UpdateClient updateCLient = new UpdateClient(_id);
            updateCLient.ShowDialog();

            string fname = updateCLient.GetAddText[0];
            string lname = updateCLient.GetAddText[1];
            string residency = updateCLient.GetAddText[2];
            DateTime date = updateCLient.dateValue;

            var selectedClient = _context.CLIENTs.Where(q => q.Id == _id).FirstOrDefault();

            selectedClient.FirstName = fname;
            selectedClient.Lastname = lname;
            selectedClient.Residency = residency;
            selectedClient.Birthday = date;

            _context.SaveChanges();

            _bindingSource.DataSource = _context.CLIENTs.ToList();
        }

        public void deleteClients(int _id)
        {
            var itemToDelete = _context.CLIENTs.Where(q => q.Id == _id).FirstOrDefault();

            _context.CLIENTs.Remove(itemToDelete);
            _context.SaveChanges();

            _bindingSource.DataSource = _context.CLIENTs.ToList();
        }

        public void searchClient(string text)
        {
            try
            {
                int id;
                bool isId = int.TryParse(text, out id);

                var result = _context.CLIENTs
                    .Where(c => (isId && c.Id == id) ||
                                c.FirstName.Contains(text) ||
                                c.Lastname.Contains(text) ||
                                c.Residency.Contains(text))
                    .Select(c => new
                    {
                        c.Id,
                        c.FirstName,
                        c.Lastname,
                        c.Residency,
                        c.Birthday
                    })
                    .ToList();

                _bindingSource.DataSource = result;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
