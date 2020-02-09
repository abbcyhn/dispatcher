namespace Dispatcher.WebUI.Models.Room
{
    using Shared;
    using Entity.Entities;
    using UnitOfWorkPattern;
    using System.Collections.Generic;

    public class RoomAddOrEditModel : AddOrEditViewModel
    {
        public RoomAddOrEditModel(IUnitOfWork uow, string postUrl, int entityId = 0) : base(uow, postUrl, entityId) { }

        public Room Room
        {
            get
            {
                return Uow.Rooms.SelectById(EntityId) ?? new Room();
            }
        }
        public IEnumerable<GenericViewModel<Building>> BuildingModels
        {
            get
            {
                var buildings = Uow.Buildings.SelectAll();
                var selectedBuilding = new List<Building> { Room.Building };

                return GenericModelCreator.GetGenericModel(buildings, selectedBuilding);
            }
        }
        public IEnumerable<GenericViewModel<RoomType>> RoomTypeModels
        {
            get
            {
                var roomTypes = Uow.RoomTypes.SelectAll();
                var selectedRoomType = new List<RoomType> { Room.RoomType };

                return GenericModelCreator.GetGenericModel(roomTypes, selectedRoomType);
            }
        }
    }
}