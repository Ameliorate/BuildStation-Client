using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Buildstation_Client2.Class
{
    static class ContentPasser
    {
        private static ContentManager Content;

        /// <summary>
        /// Sort of half initalises the class by giving it a contentmanager to pass around. Makes things hapen.
        /// </summary>
        /// <param name="_Content">The contentmanager. Content in the main class.</param>
        public static void GiveContent(ContentManager _Content)
        {
            Content = _Content;
        }

        /// <summary>
        /// Gets a contentmanager to allow for some graphics things.
        /// </summary>
        /// <returns>Returns a copy of the contentmanager.</returns>
        public static ContentManager GetContent()
        {
            return Content;
        }
    }
}
