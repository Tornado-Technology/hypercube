﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hypercube.Shared.Math.Vector;

namespace Hypercube.Shared.Math.Matrix;

[StructLayout(LayoutKind.Sequential)]
public struct Matrix3X3(Vector3 x, Vector3 y, Vector3 z)
{
    private const int IndexRaw0 = 0;
    private const int IndexRaw1 = 1;
    private const int IndexRaw2 = 2;

    private const int IndexColumn0 = 0;
    private const int IndexColumn1 = 1;
    private const int IndexColumn2 = 2;
    
    public static Matrix3X3 Zero => new(Vector3.Zero);
    public static Matrix3X3 One => new(Vector3.One);
    public static Matrix3X3 Identity => new(Vector3.Right, Vector3.Up, Vector3.Forward);
    
    public Vector3 Raw0 = x;
    public Vector3 Raw1 = y;
    public Vector3 Raw2 = z;

    /// <summary>
    /// Matrix x: 0, y: 0 element.
    /// </summary>
    public float M00
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw0.X;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw0 = Raw0.WithX(value);
    }
    
    /// <summary>
    /// Matrix x: 1, y: 0 element.
    /// </summary>
    public float M01
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw0.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw0 = Raw0.WithY(value);
    }
    
    /// <summary>
    /// Matrix x: 2, y: 0 element.
    /// </summary>
    public float M02
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw0.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw0 = Raw0.WithZ(value);
    }
    
    /// <summary>
    /// Matrix x: 0, y: 1 element.
    /// </summary>
    public float M10 
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw1.X;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw1 = Raw1.WithX(value);
    }
    
    /// <summary>
    /// Matrix x: 1, y: 1 element.
    /// </summary>
    public float M11
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw1.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw1 = Raw1.WithY(value);
    }

    /// <summary>
    /// Matrix x: 2, y: 1 element.
    /// </summary>
    public float M12
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw1.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw1 = Raw1.WithZ(value);
    }
    
    /// <summary>
    /// Matrix x: 0, y: 2 element.
    /// </summary>
    public float M20
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw2.X;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw2 = Raw2.WithX(value);
    }
    
    /// <summary>
    /// Matrix x: 1, y: 2 element.
    /// </summary>
    public float M21
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw2.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw2 = Raw2.WithY(value);
    }
    
    /// <summary>
    /// Matrix x: 2, y: 2 element.
    /// </summary>
    public float M22
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Raw2.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Raw2 = Raw2.WithZ(value);
    }

    public float this[int raw, int colum]
    {
        get => raw switch
        {
            IndexRaw0 => colum switch
            {
                IndexColumn0 => M00,
                IndexColumn1 => M01,
                IndexColumn2 => M02,
                _ => throw new ArgumentOutOfRangeException(nameof(colum), colum, null)
            },
            IndexRaw1 => colum switch
            {
                IndexColumn0 => M10,
                IndexColumn1 => M11,
                IndexColumn2 => M12,
                _ => throw new ArgumentOutOfRangeException(nameof(colum), colum, null)
            },
            IndexRaw2 => colum switch
            {
                IndexColumn0 => M20,
                IndexColumn1 => M21,
                IndexColumn2 => M22,
                _ => throw new ArgumentOutOfRangeException(nameof(colum), colum, null)
            },
            _ => throw new ArgumentOutOfRangeException(nameof(raw), raw, null)
        };
        set
        {
            switch (raw)
            {
                case IndexRaw0:
                    switch (colum)
                    {
                        case IndexColumn0:
                            M00 = value;
                            break;
                        
                        case IndexColumn1:
                            M01 = value;
                            break;
                        
                        case IndexColumn2:
                            M02 = value;
                            break;
                        
                        default:
                            throw new ArgumentOutOfRangeException(nameof(colum), colum, null);
                    }
                    break;
                    
                case IndexRaw1:
                    switch (colum)
                    {
                        case IndexColumn0:
                            M10 = value;
                            break;
                        
                        case IndexColumn1:
                            M11 = value;
                            break;
                        
                        case IndexColumn2:
                            M12 = value;
                            break;
                        
                        default:
                            throw new ArgumentOutOfRangeException(nameof(colum), colum, null);
                    }
                    break;
                
                case IndexRaw2:
                    switch (colum)
                    {
                        case IndexColumn0:
                            M20 = value;
                            break;
                        
                        case IndexColumn1:
                            M21 = value;
                            break;
                        
                        case IndexColumn2:
                            M22 = value;
                            break;
                        
                        default:
                            throw new ArgumentOutOfRangeException(nameof(colum), colum, null);
                    }
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(raw), raw, null);
            }
        }
    }
    
    public Matrix3X3(Vector3 value) : this(value, value, value)
    {
    }
    
    public Matrix3X3(float m00, float m01, float m02,
        float m10, float m11, float m12,
        float m20, float m21, float m22) : this(new Vector3(m00, m01, m02),
        new Vector3(m10, m11, m12),
        new Vector3(m20, m21, m22))
    {
    }
    
    /// <summary>
    /// Creating translation matrix
    /// <code>
    ///  1  |  0  |  x 
    ///  0  |  1  |  y
    ///  0  |  0  |  1
    /// </code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix3X3 CreateTranslation(Vector2 position)
    {
        return CreateTranslation(position.X, position.Y);
    }
    
    /// <summary>
    /// Creating translation matrix
    /// <code>
    ///  1  |  0  |  x 
    ///  0  |  1  |  y
    ///  0  |  0  |  1
    /// </code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix3X3 CreateTranslation(float x, float y)
    {
        var result = Identity;

        result.M02 = x;
        result.M12 = y;
        
        return result;
    }
    
    /// <summary>
    /// Creating rotation matrix
    /// <code>
    /// cos | -sin |  0
    /// sin |  cos |  0
    ///  0  |   0  |  1
    /// </code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix3X3 CreateRotation(Angle angle)
    {
        return CreateRotation(angle.Theta);
    }

    /// <summary>
    /// Creating rotation matrix
    /// <code>
    /// cos | -sin |  0
    /// sin |  cos |  0
    ///  0  |   0  |  1
    /// </code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix3X3 CreateRotation(double angle)
    {
        var cos = (float)System.Math.Cos(angle);
        var sin = (float)System.Math.Sin(angle);
        
        var result = Identity;

        result.M00 = cos;
        result.M01 = -sin;
        
        result.M10 = sin;
        result.M11 = cos;
        
        return result;
    }
    
    /// <summary>
    /// Creating scale matrix
    /// <code>
    ///  x  |  0  |  0 
    ///  0  |  y  |  0
    ///  0  |  0  |  1
    /// </code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix3X3 CreateScale(Vector2 scale)
    {
        return CreateScale(scale.X, scale.Y);
    }

    /// <summary>
    /// Creating scale matrix
    /// <code>
    ///  x  |  0  |  0 
    ///  0  |  y  |  0
    ///  0  |  0  |  1
    /// </code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix3X3 CreateScale(float x, float y)
    {
        var result = Identity;

        result.M00 = x;
        result.M11 = y;
        
        return result;
    }

    /// <summary>
    /// Creating transform matrix
    /// <code>
    /// cos | -sin |  x
    /// sin |  cos |  y
    ///  0  |   0  |  1
    /// </code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix3X3 CreateTransform(Vector2 position, Angle angle)
    {
        return CreateTransform(position, angle, Vector2.One);
    }
    
    /// <summary>
    /// Creating scaled transform matrix
    /// <code>
    /// cos * scale.X | -sin * scale.Y |  x
    /// sin * scale.X |  cos * scale.Y |  y
    ///       0       |       0        |  1
    /// </code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Matrix3X3 CreateTransform(Vector2 position, Angle angle, Vector2 scale)
    {
        var sin = (float)System.Math.Sin(angle.Theta);
        var cos = (float)System.Math.Cos(angle.Theta);

        var result = Identity;

        result.M00 = cos * scale.X;
        result.M01 = -sin * scale.Y;
        result.M02 = position.X;
        
        result.M10 = sin * scale.X;
        result.M11 = cos * scale.Y;
        result.M12 = position.Y;

        return result;
    }

    public static Vector3 operator *(Matrix3X3 a, Vector3 b)
    {
        return a.Raw0 * b.X + a.Raw1 * b.Y + a.Raw2 * b.Z;
    }
}