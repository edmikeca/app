﻿ using System.Collections.Generic;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.web
{  
  [Subject(typeof(ViewProductsInADepartment))]  
  public class ViewProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<IImplementAUserStory,
      ViewProductsInADepartment>
    {
        
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutARequest>();
        products = depends.on<IFindProducts>();
        selected_department = new DepartmentLineItem();
        display_engine = depends.on<IDisplayInformation>();
        products_in_department = new List<ProductLineItem>
        {
          new ProductLineItem()
        };

        request.setup(x => x.map<DepartmentLineItem>()).Return(selected_department);
        products.setup(x => x.get_the_products_in_the_department(selected_department)).Return(products_in_department);
      };

      Because b = () =>
        sut.process(request);

      It display_products_in_the_department = () =>
        display_engine.received(x => x.display(products_in_department));

      static IFindProducts products;
      static IProvideDetailsAboutARequest request;
      static IDisplayInformation display_engine;
      static IEnumerable<ProductLineItem> products_in_department;
      static DepartmentLineItem selected_department;
    }
  }
}
