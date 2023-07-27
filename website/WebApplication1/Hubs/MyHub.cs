using Microsoft.AspNetCore.SignalR;


namespace SignalR.Hubs
{
    public class MyHub:Hub
    {
        // async unke sth jo wait krty hain aur client side pr awake
        public async Task SendMessage(string message)
        {
            //new
            //message += "Hello";  

            //old
            //await Clients.Caller.SendAsync("ReceiveMessage", message); // real time comm krni to msg kisey send ? tamam open windows ko ? all mtlb sb opened windows ko .
            //await Clients.Others.SendAsync("ReceiveMessage", message); // real time comm krni to msg kisey send ? tamam open windows ko ? all mtlb sb opened windows ko .
            await Clients.All.SendAsync("ReceiveMessage", message); // real time comm krni to msg kisey send ? tamam open windows ko ? all mtlb sb opened windows ko .
         ///////////////////////////////// ye ek function name ha jo client side pr define hga , woh data jo send krna
        }
       
    }
}
