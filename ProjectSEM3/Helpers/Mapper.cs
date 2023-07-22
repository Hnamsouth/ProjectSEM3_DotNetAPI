using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace ProjectSEM3.Helpers
{
    public class Mapper<T, H> where H : new()
    {
        /// <summary>
        ///     Map dữ liệu của một class entity hoặc DTO với 1 class Entity hoặc DTO muốn chuyển đổi dữ liệu
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Hàm này có 2 tham số truyền vào, tham số đầu tiên là đối tượng đã có dữ liệu,
        ///         tham số thứ 2 là đối tượng có hoặc chưa có dữ liệu
        ///     </para>
        ///     <para>
        ///         Lưu ý, nếu không truyền vào tham số thứ 2(tức đối tượng nhận dữ liệu sau khi chuyển đổi)
        ///         thì đối tượng thứ 2 sẽ được tự động khởi tạo và trả về
        ///     </para>
        /// </remarks>
        /// <param name="t">
        ///     Đối tượng dã có dữ liệu, cần chuyển đổi sang đối tượng khác
        ///     the changes have been sent successfully to the database.
        /// </param>
        /// <param name="h">
        ///     Đối tượng cần được chuyển dữ liệu sang, đối tượng này có thể đã có dữ liệu hoặc là 1 đối tượng mới
        ///     the changes have been sent successfully to the database.
        /// </param>
        public static H Map(T t, H h)
        {
            // lấy ra hết tất cả các properties của đối tượng(class/obj) mục tiêu
            var listTargetProperties = typeof(T).GetProperties();
            // lấy ra hết tất cả các properties của đối tượng(class/obj) muốn chuyển dữ liệu sang
            var listProperties = typeof(H).GetProperties();
            // sau đó thực hiện vòng lặp kiểm tra các properties, nếu trùng tên nhau thì gán lại dữ liệu của đối tượng mục tiêu cho đối tượng muốn chuyển dữ liệu sang
            foreach ( var property in listProperties)
            {
                foreach( var targetProperty in listTargetProperties)
                {
                    if(targetProperty.Name == property.Name)
                    {
                        h.GetType().GetProperty(property.Name).SetValue(h, t.GetType().GetProperty(targetProperty.Name).GetValue(t));
                    }
                }
            }
            // sau đó trả về đối tượng đã dược chuyển dữ liệu sang
            return h;
        }

        /// <summary>
        ///     Map dữ liệu của một class entity hoặc DTO với 1 class Entity hoặc DTO muốn chuyển đổi dữ liệu
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Hàm này có 2 tham số truyền vào, tham số đầu tiên là đối tượng đã có dữ liệu,
        ///         tham số thứ 2 là đối tượng có hoặc chưa có dữ liệu
        ///     </para>
        ///     <para>
        ///         Lưu ý, nếu không truyền vào tham số thứ 2(tức đối tượng nhận dữ liệu sau khi chuyển đổi)
        ///         thì đối tượng thứ 2 sẽ được tự động khởi tạo và trả về
        ///     </para>
        /// </remarks>
        /// <param name="t">
        ///     Đối tượng dã có dữ liệu, cần chuyển đổi sang đối tượng khác
        ///     the changes have been sent successfully to the database.
        /// </param>
        public static H Map(T t)
        {
            H h = new H();
            // lấy ra hết tất cả các properties của đối tượng(class/obj) mục tiêu
            var listTargetProperties = typeof(T).GetProperties();
            // lấy ra hết tất cả các properties của đối tượng(class/obj) muốn chuyển dữ liệu sang
            var listProperties = typeof(H).GetProperties();
            // sau đó thực hiện vòng lặp kiểm tra các properties, nếu trùng tên nhau thì gán lại dữ liệu của đối tượng mục tiêu cho đối tượng muốn chuyển dữ liệu sang
            foreach (var property in listProperties)
            {
                foreach (var targetProperty in listTargetProperties)
                {
                    if (targetProperty.Name == property.Name)
                    {
                        h.GetType().GetProperty(property.Name).SetValue(h, t.GetType().GetProperty(targetProperty.Name).GetValue(t));
                    }
                }
            }
            // sau đó trả về đối tượng đã dược chuyển dữ liệu sang
            return h;
        }

        /// <summary>
        ///     Map dữ liệu của một List các entity hoặc DTO với 1 List các Entity hoặc DTO muốn chuyển đổi dữ liệu
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Hàm này có 2 tham số truyền vào, tham số đầu tiên là danh sách(List) đối tượng đã có dữ liệu,
        ///         tham số thứ 2 là danh sách(List) đối tượng có hoặc chưa có dữ liệu
        ///     </para>
        ///     <para>
        ///         Lưu ý, nếu không truyền vào tham số thứ 2(tức danh sách(List) đối tượng nhận dữ liệu sau khi chuyển đổi)
        ///         thì anh sách(List) đối tượng thứ 2 sẽ được tự động khởi tạo và trả về
        ///     </para>
        /// </remarks>
        /// <param name="listT">
        ///     Danh sách đối tượng dã có dữ liệu, cần chuyển đổi sang danh sách đối tượng khác
        /// </param>
        /// <param name="listH">
        ///     Danh sách đối tượng cần được chuyển dữ liệu sang, danh sách đối tượng này có thể đã có dữ liệu hoặc là 1 danh sách rỗng
        /// </param>
        public static List<H> MapList(List<T> listT, List<H> listH = null)
        {
            List<H> listNewH = listH != null ? listH : new List<H>();
            foreach ( var item in listT)
            {
                H h = Map(item);
                listNewH.Add(h);
            }
            return listNewH;
        }
    }
}