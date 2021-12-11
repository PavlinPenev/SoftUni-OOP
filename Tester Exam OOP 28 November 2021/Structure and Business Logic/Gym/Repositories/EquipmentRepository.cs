using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> _models = new List<IEquipment>();

        public IReadOnlyCollection<IEquipment> Models => _models;
        public void Add(IEquipment model)
        {
            _models.Add(model);
        }

        public bool Remove(IEquipment model)
            => _models.Remove(model);

        public IEquipment FindByType(string type)
            => _models.Where(e => e.GetType().Name == type).FirstOrDefault();
    }
}
