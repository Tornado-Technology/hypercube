﻿using Hypercube.Client.Graphics.Texturing.TextureSettings;
using Hypercube.Client.Utilities;
using OpenToolkit.Graphics.OpenGL4;
using TextureTarget = Hypercube.Client.Graphics.Texturing.TextureSettings.TextureParameters.TextureTarget;

namespace Hypercube.Client.Graphics.Texturing;

public sealed class TextureHandle : ITextureHandle
{
    public TextureHandle(ITexture texture, ITextureCreationSettings settings)
    {
        Handle = GL.GenTexture();
        Texture = texture;

        var target = settings.TextureTarget.ToOpenToolkit();

        GL.BindTexture(target, Handle);
        
        foreach (var param in settings.Parameters)
        {
            GL.TexParameter(target, param.Key.ToOpenToolkit(), param.Value);
        }
        
        GL.TexImage2D(
            target, 
            settings.Level, 
            settings.PixelInternalFormat.ToOpenToolkit(), 
            texture.Width, texture.Height, 
            settings.Border, 
            settings.PixelFormat.ToOpenToolkit(), 
            settings.PixelType.ToOpenToolkit(), 
            texture.Data);
        
        GL.GenerateMipmap((GenerateMipmapTarget)target);
    }

    public int Handle { get; }
    public ITexture Texture { get; }
    public void Bind(TextureTarget target)
    {
        GL.BindTexture(target.ToOpenToolkit(), Handle);
    }

    public void Unbind(TextureTarget target)
    {
        GL.BindTexture(target.ToOpenToolkit(), 0);
    }

    public void Dispose()
    {
        GL.DeleteTexture(Handle);
    }
}