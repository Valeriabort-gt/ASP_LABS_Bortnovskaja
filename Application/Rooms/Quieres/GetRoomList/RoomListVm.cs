namespace Application.Rooms.Quieres.GetRoomList
{
    public class RoomListVm
    {
        public IList<RoomLookupDto> rooms { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
