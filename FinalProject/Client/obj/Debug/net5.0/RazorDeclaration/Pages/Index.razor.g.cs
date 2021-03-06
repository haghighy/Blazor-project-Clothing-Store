// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FinalProject.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using FinalProject.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using FinalProject.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "c:\git\AP99002\FinalProject\Client\_Imports.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
using FinalProject.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 99 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
 
    private Information info = new Information();
        private void AddData(){
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
                                       
        info = new Information();
    }
        private string error = "";
        private void ErrorMethod(){
        error = "invalid input";
        }

        public int FinalPrice;
        public List<Clothe> Cartclothes = new List<Clothe>();
        private Clothe add_clothe = new Clothe();
        List<Clothe> Clothes {get; set;}
            string make_item;

        [Parameter]
        public int myvalue{ get; set; }
        protected override async Task OnInitializedAsync()
        {
            var URL =@"https://d99521226.herokuapp.com/api/Clothe/GetAllClothesFromDb";
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 121 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
                                                                                   
            Clothes = await Client.GetFromJsonAsync<List<Clothe>>(URL);
            NavigationManager.LocationChanged += HandleLocationChanged;
        }

        public async Task Remove(int id)
        {
            var URL =@"https://d99521226.herokuapp.com/api/Clothe/DeleteClotheFromDb/"+ id.ToString();
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
                                                                                                  
            await Client.DeleteAsync(URL);
            await OnInitializedAsync();
        }

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 149 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
            

        public async Task Update(Clothe clothe2)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 153 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
                                                                                          
            var URL =@"https://d99521226.herokuapp.com/api/Clothe/updateClotheFromDb"; 
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
                                                                                   
            await Client.PutAsJsonAsync(URL, clothe2);
            Cartclothes.Add(clothe2);
            
            FinalPrice += clothe2.price;
            await OnInitializedAsync();
        }


        private void NavigateToCounterComponent()
        {
            NavigationManager.NavigateTo($"navigate/{myvalue}");
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 167 "c:\git\AP99002\FinalProject\Client\Pages\Index.razor"
                                                                     
        }

        private void NavigateToAddComponent()
        {
            NavigationManager.NavigateTo("addNew");
        }


        private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            Logger.LogInformation("URL of new location: {Location}", e.Location);
        }

        public void Dispose()
        {
            
            NavigationManager.LocationChanged -= HandleLocationChanged;
        }




#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<Navigate> Logger { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Client { get; set; }
    }
}
#pragma warning restore 1591
