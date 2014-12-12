using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Buildstation_Client2.Class
{
    static class ContentLoader
    {
        
        static Dictionary<string, Texture2D> ContentTextures = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Loads a texture into the texture dictionary.
        /// </summary>
        /// <param name="Name">The name of the texture you want to add.</param>
        /// <param name="TexturePath">The path of the texture you want to add.</param>
        /// <param name="Content">The contentmanager. This should be "this.Content" in the main game file, but if it isn't, You need to take "ContentManager Content" as a parameter.</param>
        static public void AddTexture(string Name, string TexturePath, ContentManager Content)     
        {
            if (ContentTextures.ContainsKey(Name) == true)     // If it already has an entry under that name, stop right there and do nothing else. An error isn't needed since it is likely also assigning the same texture.
            {
            }
            else
            {
                ContentTextures.Add(Name, Content.Load<Texture2D>(TexturePath));        // Loads the texture.
            }
        }

        /// <summary>
        ///  Gets the texture from the dictionary.
        /// </summary>
        /// <param name="Name"> The name of the texture you want to get. </param>
        /// <returns>Returns the texture you want.</returns>


        static public Texture2D GetTexture(string Name)        // Gets the texture from the dictionary.
        {
            return ContentTextures[Name];
        }

    }
}
