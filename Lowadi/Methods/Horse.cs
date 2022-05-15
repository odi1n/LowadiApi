using Lowadi.Others;

namespace Lowadi.Methods
{
    public class Horse
    {
        public Sale Sale;
        private Request _request;

        public Horse(Request request)
        {
            this._request = request;
            this.Sale = new Sale(request);
        }
    }
}