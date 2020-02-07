using Core.Domain.Booking.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Booking
{
    public interface IBookingService
    {
        #region Command
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> CreateBooking(BookingCreateInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> UpdateBooking(BookingUpdateInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> CancelBooking(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DoneBooking(Guid id);
        #endregion
        #region Query
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Entities.Booking.Booking>> ListBooking();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Entities.Booking.Booking> Get(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Entities.Booking.Booking> Trusted_Get(Guid id);
        #endregion
    }
}
