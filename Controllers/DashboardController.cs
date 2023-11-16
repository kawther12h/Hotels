using Hotels.Data;
using Hotels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;using MailKit.Net.Smtp;

namespace Hotels.Controllers
{
    public class DashboardController : Controller

    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
                
        }
		//bsbu qnut iyrw clrw

        public async Task<string> SendEmail()
        {
            var Message = new MimeMessage();
			Message.From.Add(new MailboxAddress("Test Message", "emailExampleFrom@gmail.com"));
			Message.To.Add(MailboxAddress.Parse("emailExampleTo@gmail.com"));
			Message.Subject = "Test Email From My Project in Asp.net Core MVC";
			Message.Body = new TextPart("plain")
            {
                Text = "Welcom in My App"
            };
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate("emailExampleFrom@gmail.com", "bsbuqnutiyrwclrw");
                    await client.SendAsync(Message);
                    client.Disconnect(true);

                }
                catch(Exception e)
                {
                    return e.Message.ToString();
                }
                return "Ok";
            }
        }
		[Authorize]
        public IActionResult Index()
        {
            var currentUser = HttpContext.User.Identity.Name;
            ViewBag.currenUser = currentUser;
			HttpContext.Session.SetString("UserName", currentUser);
            

			//CookieOptions option = new CookieOptions();
			//option.Expires = DateTime.Now.AddMinutes(20);//
			//Response.Cookies.Append("UserName", currenUser, option);//store the cookies


			var hotel = _context.hotel.ToList();

            return View(hotel);
        }
        [HttpPost]
        public IActionResult Index(string city)
        {
            var hotelFilter = _context.hotel.Where(x => x.City.Contains(city));
            return View(hotelFilter);
        }
        public IActionResult CreateNewHotel(Hotel hotels)
        {
            if(ModelState.IsValid)
            {
                _context.hotel.Add(hotels);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var hotel = _context.hotel.ToList();
            return View("Index",hotel);
            

        }
        public IActionResult Delete(int id)
        {
            var hotelDelete = _context.hotel.SingleOrDefault(x => x.Id == id);
            if (hotelDelete != null)
            {
                _context.hotel.Remove(hotelDelete);
                _context.SaveChanges();
                TempData["Del"] = "Ok";
            }
            return RedirectToAction("Index");
        }
		public IActionResult Edit(int id)
		{
			var hotelEdit = _context.hotel.SingleOrDefault(x => x.Id == id);
			return View(hotelEdit);
		}
        public IActionResult Update(Hotel hotel)
        {
            _context.hotel.Update(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Rooms()

        {
            var hotel = _context.hotel.ToList();
            ViewBag.hotel = hotel;
            //ViewBag.currenUser = Request.Cookies["UserName"];
            ViewBag.currentUser = HttpContext.Session.GetString("UserName");
			var rooms = _context.rooms.ToList ();
			return View(rooms);
        }
        public IActionResult CreateNewRooms(Room rooms)
        {
            _context.rooms.Add(rooms);
            _context.SaveChanges();
            return RedirectToAction("Rooms");
        }
		public IActionResult RoomDetails()

		{
			var hotel = _context.hotel.ToList();
			ViewBag.hotel = hotel;
			ViewBag.currentUser = HttpContext.Session.GetString("UserName");

			var rooms = _context.rooms.ToList();
			ViewBag.rooms = rooms;

			var roomDetails = _context.roomDetails.ToList();
			return View(roomDetails);
		}
		public IActionResult CreateNewRoomsDetails(RoomDetails roomDetails)
		{
			_context.roomDetails.Add(roomDetails);
			_context.SaveChanges();
			return RedirectToAction("RoomDetails");
		}

	}
}
