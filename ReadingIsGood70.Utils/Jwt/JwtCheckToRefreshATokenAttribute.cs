namespace ReadingIsGood70.Utils.Jwt
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtCheckToRefreshATokenAttribute : JwtCheckBaseAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathSegments"></param>
        public JwtCheckToRefreshATokenAttribute(params string[] pathSegments) : base(pathSegments)
        {
        }
    }
}