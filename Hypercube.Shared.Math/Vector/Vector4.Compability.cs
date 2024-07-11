﻿using System.Runtime.CompilerServices;

namespace Hypercube.Shared.Math.Vector;

public readonly partial struct Vector4
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector4(System.Numerics.Vector4 vector4)
    {
        return new Vector4(vector4.X, vector4.Y, vector4.Z, vector4.W);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator System.Numerics.Vector4(Vector4 vector4)
    {
        return new System.Numerics.Vector4(vector4.X, vector4.Y, vector4.Z, vector4.W);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Vector4(OpenTK.Mathematics.Vector4 vector4)
    {
        return new Vector4(vector4.X, vector4.Y, vector4.Z, vector4.W);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator OpenTK.Mathematics.Vector4(Vector4 vector4)
    {
        return new OpenTK.Mathematics.Vector4(vector4.X, vector4.Y, vector4.Z, vector4.W);
    }
}