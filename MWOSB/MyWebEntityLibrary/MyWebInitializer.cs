using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MyWebEntityLibrary
{
    internal class MyWebInitializer : CreateDatabaseIfNotExists<MyWebContext>
    {
        public MyWebInitializer() { }

        protected override void Seed(MyWebContext context)
        {
            base.Seed(context);

            using (var ct = new MyWebContext()) 
            {
                ct.Articles.Add(
                    new ArticlesEntity.ArticlesTable
                    ()
                    {
                        ArticleAuthor = "admin",
                        ArticleContent =
                        "<p style=\"text-align:justify\">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed felis nisi, porta eget tincidunt in, aliquet eget turpis. Aliquam erat volutpat. Duis rutrum diam eu ex auctor, quis euismod odio posuere. Ut est ipsum, dapibus eu pretium sit amet, gravida non augue. Nullam iaculis tempor placerat. Phasellus quis tempus nibh. Etiam facilisis orci at eros rutrum sagittis. Nunc eu maximus odio. Donec sed lorem elit. Duis scelerisque varius facilisis. Nulla consequat rhoncus mauris quis congue.</p><p style=\"text-align:justify\">Ut eu tortor justo. Sed scelerisque velit a purus dapibus, ac feugiat mi bibendum. Curabitur tincidunt, velit in sagittis egestas, ipsum tortor luctus sem, a auctor dolor velit id ex. Praesent ut interdum lacus. Nullam a elit est. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Cras bibendum, leo non maximus porta, felis nunc consectetur ex, mattis hendrerit lacus risus sit amet risus. Etiam sollicitudin tincidunt accumsan. Aenean non aliquam eros. In mattis posuere nulla, porttitor ultrices lacus. Nullam vulputate, arcu ut vehicula rhoncus, lorem nisl aliquet dui, id pharetra dui nunc eu ex. Nulla eu euismod neque, ultrices tristique lacus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Praesent ut semper diam.</p><p style=\"text-align:justify\">Vestibulum aliquet enim sed est hendrerit, eu scelerisque metus tristique. Etiam semper diam ac ligula aliquet ultrices. Mauris sapien neque, gravida sit amet auctor a, rhoncus sit amet risus. Nam erat leo, aliquet id quam quis, rhoncus fermentum enim. In blandit in tellus vel fringilla. Donec lacinia felis quis turpis aliquam semper. Sed iaculis ipsum a nisi rhoncus, et venenatis libero hendrerit. Nam ultrices imperdiet eros, quis placerat ipsum pretium a. Donec in justo gravida felis sollicitudin sodales ac sed orci. Nunc pulvinar imperdiet velit in venenatis. Donec vestibulum nulla diam, non mollis ex condimentum sit amet. Duis tempor diam ac ipsum viverra cursus.</p><p style=\"text-align:justify\">Fusce nec faucibus leo. Nunc eget urna tincidunt, commodo sapien ut, suscipit turpis. Pellentesque dictum aliquam orci. Morbi vitae quam interdum, gravida orci in, vestibulum ipsum. Aenean vel est vel neque vestibulum porta. Phasellus faucibus, mi vitae gravida lobortis, leo dolor bibendum sapien, in condimentum tellus velit et urna. Fusce sed dui nec arcu posuere tincidunt sit amet ut odio. Integer dictum interdum cursus. Donec nec nisl nec tortor ultricies vehicula. Nulla auctor hendrerit congue. Vestibulum ac ullamcorper erat.</p><p style=\"text-align:justify\">Donec suscipit, turpis in vehicula sollicitudin, dui magna tempus justo, nec condimentum libero ipsum ac dolor. Proin tempor nisi lacus. Nunc mollis ultricies felis, vitae fermentum lorem fermentum ut. Integer aliquam quis quam eget semper. Aliquam luctus ut massa id molestie. Nam tristique diam sed dapibus tincidunt. Etiam ullamcorper ac quam id vulputate. Fusce sollicitudin non magna vel facilisis. Cras sit amet nibh urna. Duis malesuada posuere est sit amet aliquet. Etiam ut efficitur erat. Nullam elit ex, interdum vitae eros non, vulputate imperdiet magna. In elit arcu, placerat a magna in, auctor feugiat arcu. Duis iaculis orci ut aliquet mattis.</p>",
                        ArticleTags = "deneme",
                        ArticleTitle = "İlk Makale",
                        Date = DateTime.Now,
                        Image = "content-icon.png"
                        ,
                        SeoTitle = "ilk-makale",
                        PublishId = 1
                    }
                    );
                ct.SaveChanges();
            }


        }
    }
}
