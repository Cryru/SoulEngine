#pragma warning disable 649, 1572, 1573

// ReSharper disable RedundantUsingDirective

#region Using

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Khronos;

#endregion

// ReSharper disable StringLiteralTypo
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable JoinDeclarationAndInitializer
// ReSharper disable InvalidXmlDocComment
// ReSharper disable CommentTypo
namespace OpenGL
{
    public partial class Gl
    {
        /// <summary>
        /// [GL] Value of GL_PIXEL_PACK_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_pixel_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_pixel_buffer_object")]
        [RequiredByFeature("GL_NV_pixel_buffer_object", Api = "gles2")]
        public const int PIXEL_PACK_BUFFER = 0x88EB;

        /// <summary>
        /// [GL] Value of GL_PIXEL_UNPACK_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_pixel_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_pixel_buffer_object")]
        [RequiredByFeature("GL_NV_pixel_buffer_object", Api = "gles2")]
        public const int PIXEL_UNPACK_BUFFER = 0x88EC;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: data returns a single value, the name of the buffer object currently bound to the target
        /// Gl.PIXEL_PACK_BUFFER. If no buffer object is bound to this target, 0 is returned. The initial value is 0. See
        /// Gl.BindBuffer.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_pixel_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_pixel_buffer_object")]
        [RequiredByFeature("GL_NV_pixel_buffer_object", Api = "gles2")]
        public const int PIXEL_PACK_BUFFER_BINDING = 0x88ED;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: data returns a single value, the name of the buffer object currently bound to the target
        /// Gl.PIXEL_UNPACK_BUFFER. If no buffer object is bound to this target, 0 is returned. The initial value is 0. See
        /// Gl.BindBuffer.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_pixel_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_pixel_buffer_object")]
        [RequiredByFeature("GL_NV_pixel_buffer_object", Api = "gles2")]
        public const int PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;

        /// <summary>
        /// [GL] Value of GL_FLOAT_MAT2x3 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public const int FLOAT_MAT2x3 = 0x8B65;

        /// <summary>
        /// [GL] Value of GL_FLOAT_MAT2x4 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public const int FLOAT_MAT2x4 = 0x8B66;

        /// <summary>
        /// [GL] Value of GL_FLOAT_MAT3x2 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public const int FLOAT_MAT3x2 = 0x8B67;

        /// <summary>
        /// [GL] Value of GL_FLOAT_MAT3x4 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public const int FLOAT_MAT3x4 = 0x8B68;

        /// <summary>
        /// [GL] Value of GL_FLOAT_MAT4x2 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public const int FLOAT_MAT4x2 = 0x8B69;

        /// <summary>
        /// [GL] Value of GL_FLOAT_MAT4x3 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public const int FLOAT_MAT4x3 = 0x8B6A;

        /// <summary>
        /// [GL] Value of GL_SRGB symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_EXT_sRGB", Api = "gles1|gles2")] [RequiredByFeature("GL_EXT_texture_sRGB")]
        public const int SRGB = 0x8C40;

        /// <summary>
        /// [GL] Value of GL_SRGB8 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_sRGB")]
        [RequiredByFeature("GL_NV_sRGB_formats", Api = "gles2")]
        public const int SRGB8 = 0x8C41;

        /// <summary>
        /// [GL] Value of GL_SRGB_ALPHA symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_EXT_sRGB", Api = "gles1|gles2")] [RequiredByFeature("GL_EXT_texture_sRGB")]
        public const int SRGB_ALPHA = 0x8C42;

        /// <summary>
        /// [GL] Value of GL_SRGB8_ALPHA8 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_EXT_sRGB", Api = "gles1|gles2")] [RequiredByFeature("GL_EXT_texture_sRGB")]
        public const int SRGB8_ALPHA8 = 0x8C43;

        /// <summary>
        /// [GL] Value of GL_COMPRESSED_SRGB symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_EXT_texture_sRGB")]
        public const int COMPRESSED_SRGB = 0x8C48;

        /// <summary>
        /// [GL] Value of GL_COMPRESSED_SRGB_ALPHA symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RequiredByFeature("GL_EXT_texture_sRGB")]
        public const int COMPRESSED_SRGB_ALPHA = 0x8C49;

        /// <summary>
        /// [GL2.1] Gl.Get: params returns four values: the red, green, blue, and alpha secondary color values of the current
        /// raster
        /// position. Integer values, if requested, are linearly mapped from the internal floating-point representation such that
        /// 1.0 returns the most positive representable integer value, and -1.0 returns the most negative representable integer
        /// value. The initial value is (1, 1, 1, 1). See Gl.RasterPos.
        /// </summary>
        [RequiredByFeature("GL_VERSION_2_1")] [RemovedByFeature("GL_VERSION_3_2")]
        public const int CURRENT_RASTER_SECONDARY_COLOR = 0x845F;

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix2x3fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix2x3(int location, bool transpose, float[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 6 == 0, "empty or not multiple of 6");
            unsafe
            {
                fixed (float* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix2x3fv != null, "pglUniformMatrix2x3fv not implemented");
                    Delegates.pglUniformMatrix2x3fv(location, value.Length / 6, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix2x3fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static unsafe void UniformMatrix2x3(int location, int count, bool transpose, float* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix2x3fv != null, "pglUniformMatrix2x3fv not implemented");
            Delegates.pglUniformMatrix2x3fv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix2x3fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix2x3f<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix2x3fv != null, "pglUniformMatrix2x3fv not implemented");
#if NETCOREAPP1_1
			GCHandle valueHandle = GCHandle.Alloc(value);
			try {
				unsafe {
					Delegates.pglUniformMatrix2x3fv(location, count, transpose, (float*)valueHandle.AddrOfPinnedObject().ToPointer());
				}
			} finally {
				valueHandle.Free();
			}
#else
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix2x3fv(location, count, transpose, (float*) refValuePtr.ToPointer());
            }
#endif
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix3x2fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix3x2(int location, bool transpose, float[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 6 == 0, "empty or not multiple of 6");
            unsafe
            {
                fixed (float* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix3x2fv != null, "pglUniformMatrix3x2fv not implemented");
                    Delegates.pglUniformMatrix3x2fv(location, value.Length / 6, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix3x2fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static unsafe void UniformMatrix3x2(int location, int count, bool transpose, float* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix3x2fv != null, "pglUniformMatrix3x2fv not implemented");
            Delegates.pglUniformMatrix3x2fv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix3x2fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix3x2f<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix3x2fv != null, "pglUniformMatrix3x2fv not implemented");
#if NETCOREAPP1_1
			GCHandle valueHandle = GCHandle.Alloc(value);
			try {
				unsafe {
					Delegates.pglUniformMatrix3x2fv(location, count, transpose, (float*)valueHandle.AddrOfPinnedObject().ToPointer());
				}
			} finally {
				valueHandle.Free();
			}
#else
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix3x2fv(location, count, transpose, (float*) refValuePtr.ToPointer());
            }
#endif
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix2x4fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix2x4(int location, bool transpose, float[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 8 == 0, "empty or not multiple of 8");
            unsafe
            {
                fixed (float* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix2x4fv != null, "pglUniformMatrix2x4fv not implemented");
                    Delegates.pglUniformMatrix2x4fv(location, value.Length / 8, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix2x4fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static unsafe void UniformMatrix2x4(int location, int count, bool transpose, float* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix2x4fv != null, "pglUniformMatrix2x4fv not implemented");
            Delegates.pglUniformMatrix2x4fv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix2x4fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix2x4f<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix2x4fv != null, "pglUniformMatrix2x4fv not implemented");
#if NETCOREAPP1_1
			GCHandle valueHandle = GCHandle.Alloc(value);
			try {
				unsafe {
					Delegates.pglUniformMatrix2x4fv(location, count, transpose, (float*)valueHandle.AddrOfPinnedObject().ToPointer());
				}
			} finally {
				valueHandle.Free();
			}
#else
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix2x4fv(location, count, transpose, (float*) refValuePtr.ToPointer());
            }
#endif
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix4x2fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix4x2(int location, bool transpose, float[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 8 == 0, "empty or not multiple of 8");
            unsafe
            {
                fixed (float* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix4x2fv != null, "pglUniformMatrix4x2fv not implemented");
                    Delegates.pglUniformMatrix4x2fv(location, value.Length / 8, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix4x2fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static unsafe void UniformMatrix4x2(int location, int count, bool transpose, float* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix4x2fv != null, "pglUniformMatrix4x2fv not implemented");
            Delegates.pglUniformMatrix4x2fv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix4x2fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix4x2f<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix4x2fv != null, "pglUniformMatrix4x2fv not implemented");
#if NETCOREAPP1_1
			GCHandle valueHandle = GCHandle.Alloc(value);
			try {
				unsafe {
					Delegates.pglUniformMatrix4x2fv(location, count, transpose, (float*)valueHandle.AddrOfPinnedObject().ToPointer());
				}
			} finally {
				valueHandle.Free();
			}
#else
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix4x2fv(location, count, transpose, (float*) refValuePtr.ToPointer());
            }
#endif
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix3x4fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix3x4(int location, bool transpose, float[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 12 == 0, "empty or not multiple of 12");
            unsafe
            {
                fixed (float* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix3x4fv != null, "pglUniformMatrix3x4fv not implemented");
                    Delegates.pglUniformMatrix3x4fv(location, value.Length / 12, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix3x4fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static unsafe void UniformMatrix3x4(int location, int count, bool transpose, float* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix3x4fv != null, "pglUniformMatrix3x4fv not implemented");
            Delegates.pglUniformMatrix3x4fv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix3x4fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix3x4f<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix3x4fv != null, "pglUniformMatrix3x4fv not implemented");
#if NETCOREAPP1_1
			GCHandle valueHandle = GCHandle.Alloc(value);
			try {
				unsafe {
					Delegates.pglUniformMatrix3x4fv(location, count, transpose, (float*)valueHandle.AddrOfPinnedObject().ToPointer());
				}
			} finally {
				valueHandle.Free();
			}
#else
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix3x4fv(location, count, transpose, (float*) refValuePtr.ToPointer());
            }
#endif
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix4x3fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix4x3(int location, bool transpose, float[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 12 == 0, "empty or not multiple of 12");
            unsafe
            {
                fixed (float* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix4x3fv != null, "pglUniformMatrix4x3fv not implemented");
                    Delegates.pglUniformMatrix4x3fv(location, value.Length / 12, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix4x3fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static unsafe void UniformMatrix4x3(int location, int count, bool transpose, float* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix4x3fv != null, "pglUniformMatrix4x3fv not implemented");
            Delegates.pglUniformMatrix4x3fv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformMatrix4x3fv: Specify the value of a uniform variable for the current program object
        ///     </para>
        /// </summary>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be modified.
        /// </param>
        /// <param name="count">
        /// For the vector (Gl.Uniform*v) commands, specifies the number of elements that are to be modified. This should be 1 if
        /// the targeted uniform variable is not an array, and 1 or more if it is an array.
        /// </param>
        /// <param name="transpose">
        /// For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.
        /// </param>
        /// <param name="value">
        /// Values that will be used to update the specified uniform variable.
        /// used
        /// to update the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_2_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
        public static void UniformMatrix4x3f<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix4x3fv != null, "pglUniformMatrix4x3fv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix4x3fv(location, count, transpose, (float*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        internal static unsafe partial class Delegates
        {
            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix2x3fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, float* value);

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2", EntryPoint = "glUniformMatrix2x3fvNV")]
            [ThreadStatic]
            internal static glUniformMatrix2x3fv pglUniformMatrix2x3fv;

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix3x2fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, float* value);

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2", EntryPoint = "glUniformMatrix3x2fvNV")]
            [ThreadStatic]
            internal static glUniformMatrix3x2fv pglUniformMatrix3x2fv;

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix2x4fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, float* value);

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2", EntryPoint = "glUniformMatrix2x4fvNV")]
            [ThreadStatic]
            internal static glUniformMatrix2x4fv pglUniformMatrix2x4fv;

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix4x2fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, float* value);

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2", EntryPoint = "glUniformMatrix4x2fvNV")]
            [ThreadStatic]
            internal static glUniformMatrix4x2fv pglUniformMatrix4x2fv;

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix3x4fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, float* value);

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2", EntryPoint = "glUniformMatrix3x4fvNV")]
            [ThreadStatic]
            internal static glUniformMatrix3x4fv pglUniformMatrix3x4fv;

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix4x3fv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, float* value);

            [RequiredByFeature("GL_VERSION_2_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_NV_non_square_matrices", Api = "gles2", EntryPoint = "glUniformMatrix4x3fvNV")]
            [ThreadStatic]
            internal static glUniformMatrix4x3fv pglUniformMatrix4x3fv;
        }
    }
}