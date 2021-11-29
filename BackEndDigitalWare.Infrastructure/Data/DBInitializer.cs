using BackEndDigitalWare.Domain.Entities;
using System.Linq;

namespace BackEndDigitalWare.Infrastructure.Data
{
    public static class DBInitializer
    {
        public static void Initializer(DBContext context)
        {
            context.Database.EnsureCreated();
            if (context.IdentificationType.Any() &&
                context.Mark.Any() &&
                context.Customer.Any() &&
                context.Product.Any() &&
                context.Bill.Any() &&
                context.DetailBill.Any()
                )
            {
                return;
            }

            if (!context.IdentificationType.Any())
            {
                var Author = new IdentificationType[]
                {
                    new IdentificationType {Name="Cedula de ciudadania",Synonymous="CC"},
                    new IdentificationType {Name="Cedula de extranjeria ",Synonymous="CE"},
                    new IdentificationType {Name="Numero de identificacion tributario",Synonymous="NIT"},
                    new IdentificationType {Name="Tarjeta de identidad",Synonymous="TI"}
                };
                foreach (var item in Author)
                {
                    context.IdentificationType.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.Mark.Any())
            {
                var Author = new Mark[]
                {
                    new Mark {Name="H&M"},
                    new Mark {Name="Koaj"},
                    new Mark {Name="Zara"},
                    new Mark {Name="Stradivarius"},
                    new Mark {Name="Mango"},
                };
                foreach (var item in Author)
                {
                    context.Mark.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.Customer.Any())
            {
                var Author = new Customer[]
                {
                    new Customer { CustomerId=new System.Guid("5c78b385-33a5-40a7-bc96-665bc26776f3"), Name="Annie Rojas", IdentificationNumber="1018502288", BirthDate= new System.DateTime(1980,2,14), Email="annie@gmail.com", IdentificationTypeId=1},
                    new Customer {CustomerId=new System.Guid("6f3a6f15-5b54-4a8e-ba38-544f1f0cfa8b"), Name="Kevin Carrillo", IdentificationNumber="89065273", BirthDate= new System.DateTime(1998,8,20), Email="kevin@gmail.com", IdentificationTypeId=2 },
                    new Customer {CustomerId=new System.Guid("7346cdce-d7a4-48c0-a801-15905cec8607"), Name="Liliana Riveros", IdentificationNumber="52954673", BirthDate= new System.DateTime(1979,1,2), Email="liliana@gmail.com", IdentificationTypeId=3},
                    new Customer {CustomerId=new System.Guid("d9dbb8c8-b0f9-4fb4-adc3-75214998bb83"), Name="Eduardo Zagarra", IdentificationNumber="273651293", BirthDate= new System.DateTime(1989,10,23), Email="eduardo@gmail.com", IdentificationTypeId=1},
                };
                foreach (var item in Author)
                {
                    context.Customer.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.Product.Any())
            {
                var Author = new Product[]
                {
                    new Product { Name="Pantalon",Amount=20,Availability=true,MarkId=1,Price=12.000M},
                    new Product { Name="Camisa",Amount=10,Availability=true,MarkId=2,Price=15.000M},
                    new Product { Name="Medias",Amount=15,Availability=true,MarkId=3,Price=9.000M},
                    new Product { Name="Zapatos",Amount=6,Availability=false,MarkId=4,Price=18.600M},
                    new Product { Name="Zapatos",Amount=2,Availability=false,MarkId=5,Price=3.300M},
                    new Product { Name="Chaqueta",Amount=30,Availability=true,MarkId=1,Price=23.000M},
                    new Product { Name="Pantalon",Amount=18,Availability=true,MarkId=2,Price=45.000M},
                    new Product { Name="Camisa",Amount=7,Availability=false,MarkId=3,Price=9.400M},
                };
                foreach (var item in Author)
                {
                    context.Product.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.Bill.Any())
            {
                var Author = new Bill[]
                {
                    new Bill {CustomerId= new System.Guid("5c78b385-33a5-40a7-bc96-665bc26776f3"),BillId= new System.Guid("9c62e95e-ffa5-422d-aa43-eabbb60fcb67"),Date=new System.DateTime(2000,2,14),Total=100.000M },
                    new Bill {CustomerId= new System.Guid("5c78b385-33a5-40a7-bc96-665bc26776f3"),BillId= new System.Guid("8b170d2b-f785-4d01-824a-1b41880907dc"), Date=new System.DateTime(2000,12,14),Total=200.000M },
                    new Bill {CustomerId= new System.Guid("6f3a6f15-5b54-4a8e-ba38-544f1f0cfa8b"),BillId= new System.Guid("a2fe0e06-0424-4e62-acae-599599bee93a"), Date=new System.DateTime(2002,10,20),Total=300.000M },
                    new Bill {CustomerId= new System.Guid("7346cdce-d7a4-48c0-a801-15905cec8607"),BillId= new System.Guid("52303794-a32c-4840-85c0-7f30ff853241"),Date=new System.DateTime(2003,5,6),Total=850.000M },
                };
                foreach (var item in Author)
                {
                    context.Bill.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.DetailBill.Any())
            {
                var Author = new DetailBill[]
                {
                    new DetailBill {DetailBillId=new System.Guid("d5b227dd-6cba-4ab1-9e84-5b2ff1364224"),BillId=new System.Guid("9c62e95e-ffa5-422d-aa43-eabbb60fcb67"),Amount=1,ProductId=1},
                    new DetailBill {DetailBillId=new System.Guid("ccfb19f2-fbb2-4e67-b030-e5f832be9080"),BillId=new System.Guid("9c62e95e-ffa5-422d-aa43-eabbb60fcb67"),Amount=2,ProductId=2 },
                    new DetailBill {DetailBillId=new System.Guid("9c089691-c94b-4139-a7da-72f8aa328b66"),BillId=new System.Guid("8b170d2b-f785-4d01-824a-1b41880907dc"),Amount=3,ProductId=3},
                    new DetailBill {DetailBillId=new System.Guid("db073d61-c8bf-435d-b612-484a21b3f8f6"),BillId=new System.Guid("8b170d2b-f785-4d01-824a-1b41880907dc"),Amount=2,ProductId=4},
                    new DetailBill {DetailBillId=new System.Guid("01d9cf0f-499e-4fff-bcd6-3cebdb66088b"),BillId=new System.Guid("a2fe0e06-0424-4e62-acae-599599bee93a"),Amount=4,ProductId=5 },
                    new DetailBill {DetailBillId=new System.Guid("c4faa532-2029-4f35-bd97-534c5a7eb4d6"),BillId=new System.Guid("52303794-a32c-4840-85c0-7f30ff853241"),Amount=1,ProductId=1 },
                };
                foreach (var item in Author)
                {
                    context.DetailBill.Add(item);
                }
                context.SaveChanges();
            }
        }

    }
}
