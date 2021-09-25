using Application.Identity.Commands.RegisterByEmail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class Form1 : Form
    {
        //private IMediator _mediator;

        //protected IMediator Mediator
        //{
        //    get
        //    {
        //        return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        //    }
        //}


        public class MySettings
        {
            public string Text { get; set; }
            public string BackColor { get; set; }
            public string Size { get; set; }
        }


        private readonly IServiceScopeFactory _serviceScopeFactory;
        public Form1(IServiceScopeFactory serviceScopeFactory)
        {
            InitializeComponent();
            _serviceScopeFactory = serviceScopeFactory;
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            RegisterByEmailCommand query = new();

            using var scope = _serviceScopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Send(query);



            //var response = await mediator.Send(query);
            // base.OnLoad(e);
            //var mySettings = Program.Configuration.GetSection("MySettings").Get<MySettings>();
            //this.Text = mySettings.Text;
            //this.BackColor = mySettings.BackColor;
            //this.Size = mySettings.Size;
        }
    }
}
