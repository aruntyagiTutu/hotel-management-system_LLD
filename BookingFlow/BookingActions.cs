namespace HMS
{
    public interface ICommand
    {
        void Execute();
        void Undo();  // Optional, if we need to support undo operations
    }

    public class BookRoomCommand : ICommand
    {
        private BookingSystemManager _bookingManager;
        private Booking _booking;

        public BookRoomCommand(BookingSystemManager bookingManager, Booking booking)
        {
            _bookingManager = bookingManager;
            _booking = booking;
        }

        public void Execute()
        {
            _bookingManager.ManageBooking(_booking);  // Call to book a room
        }

        public void Undo()
        {
            _bookingManager.CancelBooking(_booking);  // Undo by canceling the booking
        }
    }

    public class CancelBookingCommand : ICommand
    {
        private BookingSystemManager _bookingManager;
        private Booking _booking;

        public CancelBookingCommand(BookingSystemManager bookingManager, Booking booking)
        {
            _bookingManager = bookingManager;
            _booking = booking;
        }

        public void Execute()
        {
            _bookingManager.CancelBooking(_booking);  // Call to cancel the booking
        }

        public void Undo()
        {
            _bookingManager.ManageBooking(_booking);  // Optionally, revert the cancellation
        }
    }


    public class ModifyBookingCommand : ICommand
    {
        private BookingSystemManager _bookingManager;
        private Booking _oldBooking;
        private Booking _newBooking;

        public ModifyBookingCommand(BookingSystemManager bookingManager, Booking oldBooking, Booking newBooking)
        {
            _bookingManager = bookingManager;
            _oldBooking = oldBooking;
            _newBooking = newBooking;
        }

        public void Execute()
        {
            _bookingManager.CancelBooking(_oldBooking);  // Cancel the old booking
            _bookingManager.ManageBooking(_newBooking);  // Create the new booking
        }

        public void Undo()
        {
            _bookingManager.CancelBooking(_newBooking);  // Cancel the new booking
            _bookingManager.ManageBooking(_oldBooking);  // Revert to the old booking
        }
    }



    public class BookingInvoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }

        public void UndoCommand()
        {
            _command.Undo();
        }
    }


}