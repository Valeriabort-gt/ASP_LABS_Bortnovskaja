namespace Application.Rooms.Quieres.GetRoomList
{
    public class RoomListVm
    {
        public IList<RoomLookupDto> rooms { get; set; }
        public string next { get; set; }
        public string back { get; set; }
        public int pagesCount { get; set; }
    }
}
