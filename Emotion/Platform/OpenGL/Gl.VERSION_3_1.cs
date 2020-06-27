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
        /// [GL] Value of GL_SAMPLER_2D_RECT symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ARB_shader_objects")]
        public const int SAMPLER_2D_RECT = 0x8B63;

        /// <summary>
        /// [GL] Value of GL_SAMPLER_2D_RECT_SHADOW symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ARB_shader_objects")]
        public const int SAMPLER_2D_RECT_SHADOW = 0x8B64;

        /// <summary>
        /// [GL] Value of GL_SAMPLER_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_EXT_gpu_shader4")]
        [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
        public const int SAMPLER_BUFFER = 0x8DC2;

        /// <summary>
        /// [GL] Value of GL_INT_SAMPLER_2D_RECT symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_EXT_gpu_shader4")]
        public const int INT_SAMPLER_2D_RECT = 0x8DCD;

        /// <summary>
        /// [GL] Value of GL_INT_SAMPLER_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_EXT_gpu_shader4")]
        [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
        public const int INT_SAMPLER_BUFFER = 0x8DD0;

        /// <summary>
        /// [GL] Value of GL_UNSIGNED_INT_SAMPLER_2D_RECT symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_EXT_gpu_shader4")]
        public const int UNSIGNED_INT_SAMPLER_2D_RECT = 0x8DD5;

        /// <summary>
        /// [GL] Value of GL_UNSIGNED_INT_SAMPLER_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_EXT_gpu_shader4")]
        [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
        public const int UNSIGNED_INT_SAMPLER_BUFFER = 0x8DD8;

        /// <summary>
        /// [GL] Value of GL_TEXTURE_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_buffer_object")]
        [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
        public const int TEXTURE_BUFFER = 0x8C2A;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: data returns one value. The value gives the maximum number of texels allowed in the texel array
        /// of
        /// a texture buffer object. Value must be at least 65536.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_buffer_object")]
        [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
        public const int MAX_TEXTURE_BUFFER_SIZE = 0x8C2B;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: data returns a single value, the name of the texture currently bound to the target
        /// Gl.TEXTURE_BUFFER. The initial value is 0. See Gl.BindTexture.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_VERSION_4_5")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_buffer_object")]
        [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
        public const int TEXTURE_BINDING_BUFFER = 0x8C2C;

        /// <summary>
        /// [GLES3.2] Gl.GetTexLevelParameter: params returns the name of the buffer object bound to the data store for a buffer
        /// texture. See Gl.TexBufferRange
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_buffer_object")]
        [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
        public const int TEXTURE_BUFFER_DATA_STORE_BINDING = 0x8C2D;

        /// <summary>
        /// [GL] Value of GL_TEXTURE_RECTANGLE symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_texture_rectangle")]
        [RequiredByFeature("GL_NV_texture_rectangle")]
        public const int TEXTURE_RECTANGLE = 0x84F5;

        /// <summary>
        /// [GL4] Gl.Get: data returns a single value, the name of the texture currently bound to the target Gl.TEXTURE_RECTANGLE.
        /// The initial value is 0. See Gl.BindTexture.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_VERSION_4_5")]
        [RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_texture_rectangle")]
        [RequiredByFeature("GL_NV_texture_rectangle")]
        public const int TEXTURE_BINDING_RECTANGLE = 0x84F6;

        /// <summary>
        /// [GL] Value of GL_PROXY_TEXTURE_RECTANGLE symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ARB_texture_rectangle")] [RequiredByFeature("GL_NV_texture_rectangle")]
        public const int PROXY_TEXTURE_RECTANGLE = 0x84F7;

        /// <summary>
        /// [GL4] Gl.Get: data returns one value. The value gives a rough estimate of the largest rectangular texture that the GL
        /// can handle. The value must be at least 1024. Use Gl.PROXY_TEXTURE_RECTANGLE to determine if a texture is too large. See
        /// Gl.TexImage2D.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ARB_texture_rectangle")] [RequiredByFeature("GL_NV_texture_rectangle")]
        public const int MAX_RECTANGLE_TEXTURE_SIZE = 0x84F8;

        /// <summary>
        /// [GL] Value of GL_R8_SNORM symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_snorm")]
        public const int R8_SNORM = 0x8F94;

        /// <summary>
        /// [GL] Value of GL_RG8_SNORM symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_snorm")]
        public const int RG8_SNORM = 0x8F95;

        /// <summary>
        /// [GL] Value of GL_RGB8_SNORM symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_EXT_texture_snorm")]
        public const int RGB8_SNORM = 0x8F96;

        /// <summary>
        /// [GL] Value of GL_RGBA8_SNORM symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_snorm")]
        public const int RGBA8_SNORM = 0x8F97;

        /// <summary>
        /// [GL] Value of GL_R16_SNORM symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_EXT_texture_snorm")]
        [RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
        public const int R16_SNORM = 0x8F98;

        /// <summary>
        /// [GL] Value of GL_RG16_SNORM symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_EXT_texture_snorm")]
        [RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
        public const int RG16_SNORM = 0x8F99;

        /// <summary>
        /// [GL] Value of GL_RGB16_SNORM symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_EXT_texture_snorm")] [RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
        public const int RGB16_SNORM = 0x8F9A;

        /// <summary>
        /// [GL] Value of GL_RGBA16_SNORM symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_EXT_texture_snorm")]
        [RequiredByFeature("GL_EXT_render_snorm", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_norm16", Api = "gles2")]
        public const int RGBA16_SNORM = 0x8F9B;

        /// <summary>
        /// [GL] Value of GL_SIGNED_NORMALIZED symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_EXT_texture_snorm")]
        public const int SIGNED_NORMALIZED = 0x8F9C;

        /// <summary>
        /// [GL] Value of GL_PRIMITIVE_RESTART symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] public const int PRIMITIVE_RESTART = 0x8F9D;

        /// <summary>
        /// [GL4] Gl.Get: data returns one value, the current primitive restart index. The initial value is 0. See
        /// Gl.PrimitiveRestartIndex.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] public const int PRIMITIVE_RESTART_INDEX = 0x8F9E;

        /// <summary>
        /// [GL] Value of GL_COPY_READ_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_copy_buffer", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_copy_buffer", Api = "gles2")]
        public const int COPY_READ_BUFFER = 0x8F36;

        /// <summary>
        /// [GL] Value of GL_COPY_WRITE_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_copy_buffer", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_copy_buffer", Api = "gles2")]
        public const int COPY_WRITE_BUFFER = 0x8F37;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BUFFER = 0x8A11;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: When used with non-indexed variants of glGet (such as glGetIntegerv), data returns a single
        /// value,
        /// the name of the buffer object currently bound to the target Gl.UNIFORM_BUFFER. If no buffer object is bound to this
        /// target, 0 is returned. When used with indexed variants of glGet (such as glGetIntegeri_v), data returns a single value,
        /// the name of the buffer object bound to the indexed uniform buffer binding point. The initial value is 0 for all
        /// targets.
        /// See Gl.BindBuffer, Gl.BindBufferBase, and Gl.BindBufferRange.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BUFFER_BINDING = 0x8A28;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: When used with indexed variants of glGet (such as glGetInteger64i_v), data returns a single
        /// value,
        /// the start offset of the binding range for each indexed uniform buffer binding. The initial value is 0 for all bindings.
        /// See Gl.BindBufferRange.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BUFFER_START = 0x8A29;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: When used with indexed variants of glGet (such as glGetInteger64i_v), data returns a single
        /// value,
        /// the size of the binding range for each indexed uniform buffer binding. The initial value is 0 for all bindings. See
        /// Gl.BindBufferRange.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BUFFER_SIZE = 0x8A2A;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: data returns one value, the maximum number of uniform blocks per vertex shader. The value must be
        /// at least 12. See Gl.UniformBlockBinding.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: data returns one value, the maximum number of uniform blocks per geometry shader. The value must
        /// be at least 12. See Gl.UniformBlockBinding.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
        public const int MAX_GEOMETRY_UNIFORM_BLOCKS = 0x8A2C;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: data returns one value, the maximum number of uniform blocks per fragment shader. The value must
        /// be at least 12. See Gl.UniformBlockBinding.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D;

        /// <summary>
        ///     <para>
        ///     [GL4] Gl.Get: data returns one value, the maximum number of uniform blocks per program. The value must be at least
        ///     70.
        ///     See Gl.UniformBlockBinding.
        ///     </para>
        ///     <para>
        ///     [GLES3.2] Gl.Get: data returns one value, the maximum number of uniform blocks per program. The value must be at
        ///     least
        ///     60. See Gl.UniformBlockBinding.
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E;

        /// <summary>
        ///     <para>
        ///     [GL4] Gl.Get: data returns one value, the maximum number of uniform buffer binding points on the context, which
        ///     must be
        ///     at least 36.
        ///     </para>
        ///     <para>
        ///     [GLES3.2] Gl.Get: data returns one value, the maximum number of uniform buffer binding points on the context, which
        ///     must
        ///     be at least 72.
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F;

        /// <summary>
        ///     <para>
        ///     [GL4] Gl.Get: data returns one value, the maximum size in basic machine units of a uniform block, which must be at
        ///     least
        ///     16384.
        ///     </para>
        ///     <para>
        ///     [GLES3.2] Gl.Get: data returns one value, the maximum size in basic machine units of a uniform block. The value
        ///     must be
        ///     at least 16384. See Gl.UniformBlockBinding.
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int MAX_UNIFORM_BLOCK_SIZE = 0x8A30;

        /// <summary>
        ///     <para>
        ///     [GL4] Gl.Get: data returns one value, the number of words for vertex shader uniform variables in all uniform blocks
        ///     (including default). The value must be at least 1. See Gl.Uniform.
        ///     </para>
        ///     <para>
        ///     [GLES3.2] Gl.Get: data returns one value, the number of words for vertex shader uniform variables in all uniform
        ///     blocks
        ///     (including default). The value must be at least . Gl.MAX_VERTEX_UNIFORM_COMPONENTS + Gl.MAX_UNIFORM_BLOCK_SIZE *
        ///     Gl.MAX_VERTEX_UNIFORM_BLOCKS / 4. See Gl.Uniform.
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31;

        /// <summary>
        ///     <para>
        ///     [GL4] Gl.Get: data returns one value, the number of words for geometry shader uniform variables in all uniform
        ///     blocks
        ///     (including default). The value must be at least 1. See Gl.Uniform.
        ///     </para>
        ///     <para>
        ///     [GLES3.2] Gl.Get: data returns one value, the number of words for geometry shader uniform variables in all uniform
        ///     blocks (including default). The value must be at least Gl.MAX_GEOMETRY_UNIFORM_COMPONENTS +
        ///     Gl.MAX_UNIFORM_BLOCK_SIZE *
        ///     Gl.MAX_GEOMETRY_UNIFORM_BLOCKS / 4. See Gl.Uniform.
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
        public const int MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = 0x8A32;

        /// <summary>
        ///     <para>
        ///     [GL4] Gl.Get: data returns one value, the number of words for fragment shader uniform variables in all uniform
        ///     blocks
        ///     (including default). The value must be at least 1. See Gl.Uniform.
        ///     </para>
        ///     <para>
        ///     [GLES3.2] Gl.Get: data returns one value, the number of words for fragment shader uniform variables in all uniform
        ///     blocks (including default). The value must be at least Gl.MAX_FRAGMENT_UNIFORM_COMPONENTS +
        ///     Gl.MAX_UNIFORM_BLOCK_SIZE *
        ///     Gl.MAX_FRAGMENT_UNIFORM_BLOCKS / 4. See Gl.Uniform.
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33;

        /// <summary>
        /// [GL4|GLES3.2] Gl.Get: data returns a single value, the minimum required alignment for uniform buffer sizes and offset.
        /// The initial value is 1. See Gl.UniformBlockBinding.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;

        /// <summary>
        /// [GLES3.2] Gl.GetProgram: params returns the length of the longest active uniform block name for program, including the
        /// null termination character (i.e., the size of the character buffer required to store the longest uniform block name).
        /// If
        /// no active uniform blocks exist, 0 is returned.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35;

        /// <summary>
        /// [GLES3.2] Gl.GetProgram: params returns the number of uniform blocks for program containing active uniforms.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int ACTIVE_UNIFORM_BLOCKS = 0x8A36;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_TYPE symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_TYPE = 0x8A37;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_SIZE symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_SIZE = 0x8A38;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_NAME_LENGTH symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_NAME_LENGTH = 0x8A39;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_INDEX symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_INDEX = 0x8A3A;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_OFFSET symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_OFFSET = 0x8A3B;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_ARRAY_STRIDE symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_ARRAY_STRIDE = 0x8A3C;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_MATRIX_STRIDE symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_MATRIX_STRIDE = 0x8A3D;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_IS_ROW_MAJOR symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_IS_ROW_MAJOR = 0x8A3E;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_BINDING symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_BINDING = 0x8A3F;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_DATA_SIZE symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_DATA_SIZE = 0x8A40;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_NAME_LENGTH symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_NAME_LENGTH = 0x8A41;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_ACTIVE_UNIFORMS symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_ACTIVE_UNIFORMS = 0x8A42;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 0x8A43;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 0x8A44;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER = 0x8A45;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46;

        /// <summary>
        /// [GL] Value of GL_INVALID_INDEX symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public const uint INVALID_INDEX = 0xFFFFFFFF;

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glDrawArraysInstanced: draw multiple instances of a range of elements
        ///     </para>
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLESGl.LINES_ADJACENCY, Gl.LINE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY,
        /// Gl.TRIANGLE_STRIP_ADJACENCY and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="first">
        /// Specifies the starting index in the enabled arrays.
        /// </param>
        /// <param name="count">
        /// Specifies the number of indices to be rendered.
        /// </param>
        /// <param name="primcount">
        /// Specifies the number of instances of the specified range of indices to be rendered.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ANGLE_instanced_arrays", Api = "gles2")]
        [RequiredByFeature("GL_ARB_draw_instanced", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_draw_instanced", Api = "gl|glcore|gles2")]
        [RequiredByFeature("GL_EXT_instanced_arrays", Api = "gles2")]
        [RequiredByFeature("GL_NV_draw_instanced", Api = "gles2")]
        public static void DrawArraysInstanced(PrimitiveType mode, int first, int count, int primcount)
        {
            Debug.Assert(Delegates.pglDrawArraysInstanced != null, "pglDrawArraysInstanced not implemented");
            Delegates.pglDrawArraysInstanced((int) mode, first, count, primcount);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glDrawElementsInstanced: draw multiple instances of a set of elements
        ///     </para>
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.LINE_STRIP_ADJACENCY, Gl.LINES_ADJACENCY, Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLES,
        /// Gl.TRIANGLE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="count">
        /// Specifies the number of elements to be rendered.
        /// </param>
        /// <param name="type">
        /// Specifies the type of the values in <paramref name="indices" />. Must be one of Gl.UNSIGNED_BYTE, Gl.UNSIGNED_SHORT, or
        /// Gl.UNSIGNED_INT.
        /// </param>
        /// <param name="indices">
        /// Specifies a pointer to the location where the indices are stored.
        /// </param>
        /// <param name="primcount">
        /// Specifies the number of instances of the specified range of indices to be rendered.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ANGLE_instanced_arrays", Api = "gles2")]
        [RequiredByFeature("GL_ARB_draw_instanced", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_draw_instanced", Api = "gl|glcore|gles2")]
        [RequiredByFeature("GL_EXT_instanced_arrays", Api = "gles2")]
        [RequiredByFeature("GL_NV_draw_instanced", Api = "gles2")]
        public static void DrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices, int primcount)
        {
            Debug.Assert(Delegates.pglDrawElementsInstanced != null, "pglDrawElementsInstanced not implemented");
            Delegates.pglDrawElementsInstanced((int) mode, count, (int) type, indices, primcount);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glDrawElementsInstanced: draw multiple instances of a set of elements
        ///     </para>
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.LINE_STRIP_ADJACENCY, Gl.LINES_ADJACENCY, Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLES,
        /// Gl.TRIANGLE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="count">
        /// Specifies the number of elements to be rendered.
        /// </param>
        /// <param name="type">
        /// Specifies the type of the values in <paramref name="indices" />. Must be one of Gl.UNSIGNED_BYTE, Gl.UNSIGNED_SHORT, or
        /// Gl.UNSIGNED_INT.
        /// </param>
        /// <param name="indices">
        /// Specifies a pointer to the location where the indices are stored.
        /// </param>
        /// <param name="primcount">
        /// Specifies the number of instances of the specified range of indices to be rendered.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ANGLE_instanced_arrays", Api = "gles2")]
        [RequiredByFeature("GL_ARB_draw_instanced", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_draw_instanced", Api = "gl|glcore|gles2")]
        [RequiredByFeature("GL_EXT_instanced_arrays", Api = "gles2")]
        [RequiredByFeature("GL_NV_draw_instanced", Api = "gles2")]
        public static void DrawElementsInstanced(PrimitiveType mode, int count, DrawElementsType type, object indices, int primcount)
        {
            GCHandle pin_indices = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                DrawElementsInstanced(mode, count, type, pin_indices.AddrOfPinnedObject(), primcount);
            }
            finally
            {
                pin_indices.Free();
            }
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glTexBuffer: attach a buffer object's data store to a buffer texture object
        ///     </para>
        /// </summary>
        /// <param name="target">
        /// Specifies the target to which the texture is bound for Gl.TexBuffer. Must be Gl.TEXTURE_BUFFER.
        /// </param>
        /// <param name="internalformat">
        /// A <see cref="T:InternalFormat" />.
        /// </param>
        /// <param name="buffer">
        /// Specifies the name of the buffer object whose storage to attach to the active buffer texture.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
        [RequiredByFeature("GL_EXT_texture_buffer_object")]
        [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
        public static void TexBuffer(TextureTarget target, InternalFormat internalformat, uint buffer)
        {
            Debug.Assert(Delegates.pglTexBuffer != null, "pglTexBuffer not implemented");
            Delegates.pglTexBuffer((int) target, (int) internalformat, buffer);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glPrimitiveRestartIndex: specify the primitive restart index
        /// </summary>
        /// <param name="index">
        /// Specifies the value to be interpreted as the primitive restart index.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        public static void PrimitiveRestartIndex(uint index)
        {
            Debug.Assert(Delegates.pglPrimitiveRestartIndex != null, "pglPrimitiveRestartIndex not implemented");
            Delegates.pglPrimitiveRestartIndex(index);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4] glCopyBufferSubData: copy all or part of the data store of a buffer object to the data store of another
        ///     buffer
        ///     object
        ///     </para>
        ///     <para>
        ///     [GLES3.2] glCopyBufferSubData: copy part of the data store of a buffer object to the data store of another buffer
        ///     object
        ///     </para>
        /// </summary>
        /// <param name="readTarget">
        /// Specifies the target to which the source buffer object is bound for Gl.CopyBufferSubData
        /// </param>
        /// <param name="writeTarget">
        /// Specifies the target to which the destination buffer object is bound for Gl.CopyBufferSubData.
        /// </param>
        /// <param name="readOffset">
        /// Specifies the offset, in basic machine units, within the data store of the source buffer object at which data will be
        /// read.
        /// </param>
        /// <param name="writeOffset">
        /// Specifies the offset, in basic machine units, within the data store of the destination buffer object at which data will
        /// be written.
        /// </param>
        /// <param name="size">
        /// Specifies the size, in basic machine units, of the data to be copied from the source buffer object to the destination
        /// buffer object.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_copy_buffer", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_copy_buffer", Api = "gles2")]
        public static void CopyBufferSubData(BufferTarget readTarget, BufferTarget writeTarget, IntPtr readOffset, IntPtr writeOffset, uint size)
        {
            Debug.Assert(Delegates.pglCopyBufferSubData != null, "pglCopyBufferSubData not implemented");
            Delegates.pglCopyBufferSubData((int) readTarget, (int) writeTarget, readOffset, writeOffset, size);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGetUniformIndices: retrieve the index of a named uniform block
        ///     </para>
        /// </summary>
        /// <param name="program">
        /// Specifies the name of a program containing uniforms whose indices to query.
        /// </param>
        /// <param name="uniformCount">
        /// Specifies the number of uniforms whose indices to query.
        /// </param>
        /// <param name="uniformNames">
        /// Specifies the address of an array of pointers to buffers containing the names of the queried uniforms.
        /// </param>
        /// <param name="uniformIndices">
        /// Specifies the address of an array that will receive the indices of the uniforms.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static void GetUniformIndices(uint program, int uniformCount, string[] uniformNames, [Out] uint[] uniformIndices)
        {
            unsafe
            {
                fixed (uint* p_uniformIndices = uniformIndices)
                {
                    Debug.Assert(Delegates.pglGetUniformIndices != null, "pglGetUniformIndices not implemented");
                    Delegates.pglGetUniformIndices(program, uniformCount, uniformNames, p_uniformIndices);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGetActiveUniformsiv: Returns information about several active uniform variables for the specified
        ///     program object
        ///     </para>
        /// </summary>
        /// <param name="program">
        /// Specifies the program object to be queried.
        /// </param>
        /// <param name="uniformCount">
        /// Specifies both the number of elements in the array of indices <paramref name="uniformIndices" /> and the number of
        /// parameters written to <paramref name="params" /> upon successful return.
        /// </param>
        /// <param name="uniformIndices">
        /// Specifies the address of an array of <paramref name="uniformCount" /> integers containing the indices of uniforms
        /// within
        /// <paramref name="program" /> whose parameter <paramref name="pname" /> should be queried.
        /// </param>
        /// <param name="pname">
        /// Specifies the property of each uniform in <paramref name="uniformIndices" /> that should be written into the
        /// corresponding element of <paramref name="params" />.
        /// </param>
        /// <param name="params">
        /// Specifies the address of an array of <paramref name="uniformCount" /> integers which are to receive the value of
        /// <paramref name="pname" /> for each uniform in <paramref name="uniformIndices" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static void GetActiveUniforms(uint program, int uniformCount, uint[] uniformIndices, UniformPName pname, [Out] int[] @params)
        {
            unsafe
            {
                fixed (uint* p_uniformIndices = uniformIndices)
                fixed (int* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetActiveUniformsiv != null, "pglGetActiveUniformsiv not implemented");
                    Delegates.pglGetActiveUniformsiv(program, uniformCount, p_uniformIndices, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGetActiveUniformsiv: Returns information about several active uniform variables for the specified
        ///     program object
        ///     </para>
        /// </summary>
        /// <param name="program">
        /// Specifies the program object to be queried.
        /// </param>
        /// <param name="uniformIndices">
        /// Specifies the address of an array of integers containing the indices of uniforms
        /// within
        /// <paramref name="program" /> whose parameter <paramref name="pname" /> should be queried.
        /// </param>
        /// <param name="pname">
        /// Specifies the property of each uniform in <paramref name="uniformIndices" /> that should be written into the
        /// corresponding element of <paramref name="params" />.
        /// </param>
        /// <param name="params">
        /// Specifies the address of an array of integers which are to receive the value of
        /// <paramref name="pname" /> for each uniform in <paramref name="uniformIndices" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static void GetActiveUniforms(uint program, uint[] uniformIndices, UniformPName pname, [Out] int[] @params)
        {
            unsafe
            {
                fixed (uint* p_uniformIndices = uniformIndices)
                fixed (int* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetActiveUniformsiv != null, "pglGetActiveUniformsiv not implemented");
                    Delegates.pglGetActiveUniformsiv(program, uniformIndices.Length, p_uniformIndices, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetActiveUniformName: query the name of an active uniform
        /// </summary>
        /// <param name="program">
        /// Specifies the program containing the active uniform index <paramref name="uniformIndex" />.
        /// </param>
        /// <param name="uniformIndex">
        /// Specifies the index of the active uniform whose name to query.
        /// </param>
        /// <param name="bufSize">
        /// Specifies the size of the buffer, in units of GLchar, of the buffer whose address is specified in
        /// <paramref
        ///     name="uniformName" />
        /// .
        /// </param>
        /// <param name="length">
        /// Specifies the address of a variable that will receive the number of characters that were or would have been written to
        /// the buffer addressed by <paramref name="uniformName" />.
        /// </param>
        /// <param name="uniformName">
        /// Specifies the address of a buffer into which the GL will place the name of the active uniform at
        /// <paramref
        ///     name="uniformIndex" />
        /// within <paramref name="program" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static void GetActiveUniformName(uint program, uint uniformIndex, int bufSize, out int length, StringBuilder uniformName)
        {
            unsafe
            {
                fixed (int* p_length = &length)
                {
                    Debug.Assert(Delegates.pglGetActiveUniformName != null, "pglGetActiveUniformName not implemented");
                    Delegates.pglGetActiveUniformName(program, uniformIndex, bufSize, p_length, uniformName);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGetUniformBlockIndex: retrieve the index of a named uniform block
        ///     </para>
        /// </summary>
        /// <param name="program">
        /// Specifies the name of a program containing the uniform block.
        /// </param>
        /// <param name="uniformBlockName">
        /// Specifies the address an array of characters to containing the name of the uniform block whose index to retrieve.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static uint GetUniformBlockIndex(uint program, string uniformBlockName)
        {
            uint retValue;

            Debug.Assert(Delegates.pglGetUniformBlockIndex != null, "pglGetUniformBlockIndex not implemented");
            retValue = Delegates.pglGetUniformBlockIndex(program, uniformBlockName);
            DebugCheckErrors(retValue);

            return retValue;
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGetActiveUniformBlockiv: query information about an active uniform block
        ///     </para>
        /// </summary>
        /// <param name="program">
        /// Specifies the name of a program containing the uniform block.
        /// </param>
        /// <param name="uniformBlockIndex">
        /// Specifies the index of the uniform block within <paramref name="program" />.
        /// </param>
        /// <param name="pname">
        /// Specifies the name of the parameter to query.
        /// </param>
        /// <param name="params">
        /// Specifies the address of a variable to receive the result of the query.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static void GetActiveUniformBlock(uint program, uint uniformBlockIndex, UniformBlockPName pname, [Out] int[] @params)
        {
            unsafe
            {
                fixed (int* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetActiveUniformBlockiv != null, "pglGetActiveUniformBlockiv not implemented");
                    Delegates.pglGetActiveUniformBlockiv(program, uniformBlockIndex, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGetActiveUniformBlockiv: query information about an active uniform block
        ///     </para>
        /// </summary>
        /// <param name="program">
        /// Specifies the name of a program containing the uniform block.
        /// </param>
        /// <param name="uniformBlockIndex">
        /// Specifies the index of the uniform block within <paramref name="program" />.
        /// </param>
        /// <param name="pname">
        /// Specifies the name of the parameter to query.
        /// </param>
        /// <param name="params">
        /// Specifies the address of a variable to receive the result of the query.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static void GetActiveUniformBlock(uint program, uint uniformBlockIndex, UniformBlockPName pname, out int @params)
        {
            unsafe
            {
                fixed (int* p_params = &@params)
                {
                    Debug.Assert(Delegates.pglGetActiveUniformBlockiv != null, "pglGetActiveUniformBlockiv not implemented");
                    Delegates.pglGetActiveUniformBlockiv(program, uniformBlockIndex, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGetActiveUniformBlockName: retrieve the name of an active uniform block
        ///     </para>
        /// </summary>
        /// <param name="program">
        /// Specifies the name of a program containing the uniform block.
        /// </param>
        /// <param name="uniformBlockIndex">
        /// Specifies the index of the uniform block within <paramref name="program" />.
        /// </param>
        /// <param name="bufSize">
        /// Specifies the size of the buffer addressed by <paramref name="uniformBlockName" />.
        /// </param>
        /// <param name="length">
        /// Specifies the address of a variable to receive the number of characters that were written to
        /// <paramref
        ///     name="uniformBlockName" />
        /// .
        /// </param>
        /// <param name="uniformBlockName">
        /// Specifies the address an array of characters to receive the name of the uniform block at
        /// <paramref
        ///     name="uniformBlockIndex" />
        /// .
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static void GetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, out int length, StringBuilder uniformBlockName)
        {
            unsafe
            {
                fixed (int* p_length = &length)
                {
                    Debug.Assert(Delegates.pglGetActiveUniformBlockName != null, "pglGetActiveUniformBlockName not implemented");
                    Delegates.pglGetActiveUniformBlockName(program, uniformBlockIndex, bufSize, p_length, uniformBlockName);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glUniformBlockBinding: assign a binding point to an active uniform block
        ///     </para>
        /// </summary>
        /// <param name="program">
        /// The name of a program object containing the active uniform block whose binding to assign.
        /// </param>
        /// <param name="uniformBlockIndex">
        /// The index of the active uniform block within <paramref name="program" /> whose binding to assign.
        /// </param>
        /// <param name="uniformBlockBinding">
        /// Specifies the binding point to which to bind the uniform block with index <paramref name="uniformBlockIndex" /> within
        /// <paramref name="program" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_3_1")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
        public static void UniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding)
        {
            Debug.Assert(Delegates.pglUniformBlockBinding != null, "pglUniformBlockBinding not implemented");
            Delegates.pglUniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding);
            DebugCheckErrors(null);
        }

        internal static unsafe partial class Delegates
        {
            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ANGLE_instanced_arrays", Api = "gles2")]
            [RequiredByFeature("GL_ARB_draw_instanced", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_draw_instanced", Api = "gl|glcore|gles2")]
            [RequiredByFeature("GL_EXT_instanced_arrays", Api = "gles2")]
            [RequiredByFeature("GL_NV_draw_instanced", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glDrawArraysInstanced(int mode, int first, int count, int instancecount);

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ANGLE_instanced_arrays", Api = "gles2", EntryPoint = "glDrawArraysInstancedANGLE")]
            [RequiredByFeature("GL_ARB_draw_instanced", Api = "gl|glcore", EntryPoint = "glDrawArraysInstancedARB")]
            [RequiredByFeature("GL_EXT_draw_instanced", Api = "gl|glcore|gles2", EntryPoint = "glDrawArraysInstancedEXT")]
            [RequiredByFeature("GL_EXT_instanced_arrays", Api = "gles2", EntryPoint = "glDrawArraysInstancedEXT")]
            [RequiredByFeature("GL_NV_draw_instanced", Api = "gles2", EntryPoint = "glDrawArraysInstancedNV")]
            [ThreadStatic]
            internal static glDrawArraysInstanced pglDrawArraysInstanced;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ANGLE_instanced_arrays", Api = "gles2")]
            [RequiredByFeature("GL_ARB_draw_instanced", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_draw_instanced", Api = "gl|glcore|gles2")]
            [RequiredByFeature("GL_EXT_instanced_arrays", Api = "gles2")]
            [RequiredByFeature("GL_NV_draw_instanced", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glDrawElementsInstanced(int mode, int count, int type, IntPtr indices, int instancecount);

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ANGLE_instanced_arrays", Api = "gles2", EntryPoint = "glDrawElementsInstancedANGLE")]
            [RequiredByFeature("GL_ARB_draw_instanced", Api = "gl|glcore", EntryPoint = "glDrawElementsInstancedARB")]
            [RequiredByFeature("GL_EXT_draw_instanced", Api = "gl|glcore|gles2", EntryPoint = "glDrawElementsInstancedEXT")]
            [RequiredByFeature("GL_EXT_instanced_arrays", Api = "gles2", EntryPoint = "glDrawElementsInstancedEXT")]
            [RequiredByFeature("GL_NV_draw_instanced", Api = "gles2", EntryPoint = "glDrawElementsInstancedNV")]
            [ThreadStatic]
            internal static glDrawElementsInstanced pglDrawElementsInstanced;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2")]
            [RequiredByFeature("GL_EXT_texture_buffer_object")]
            [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glTexBuffer(int target, int internalformat, uint buffer);

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_ARB_texture_buffer_object", Api = "gl|glcore", EntryPoint = "glTexBufferARB")]
            [RequiredByFeature("GL_EXT_texture_buffer", Api = "gles2", EntryPoint = "glTexBufferEXT")]
            [RequiredByFeature("GL_EXT_texture_buffer_object", EntryPoint = "glTexBufferEXT")]
            [RequiredByFeature("GL_OES_texture_buffer", Api = "gles2", EntryPoint = "glTexBufferOES")]
            [ThreadStatic]
            internal static glTexBuffer pglTexBuffer;

            [RequiredByFeature("GL_VERSION_3_1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glPrimitiveRestartIndex(uint index);

            [RequiredByFeature("GL_VERSION_3_1")] [ThreadStatic]
            internal static glPrimitiveRestartIndex pglPrimitiveRestartIndex;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_copy_buffer", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_copy_buffer", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glCopyBufferSubData(int readTarget, int writeTarget, IntPtr readOffset, IntPtr writeOffset, uint size);

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_copy_buffer", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_copy_buffer", Api = "gles2", EntryPoint = "glCopyBufferSubDataNV")]
            [ThreadStatic]
            internal static glCopyBufferSubData pglCopyBufferSubData;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetUniformIndices(uint program, int uniformCount, string[] uniformNames, uint* uniformIndices);

            [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetUniformIndices pglGetUniformIndices;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetActiveUniformsiv(uint program, int uniformCount, uint* uniformIndices, int pname, int* @params);

            [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetActiveUniformsiv pglGetActiveUniformsiv;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetActiveUniformName(uint program, uint uniformIndex, int bufSize, int* length, StringBuilder uniformName);

            [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetActiveUniformName pglGetActiveUniformName;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate uint glGetUniformBlockIndex(uint program, string uniformBlockName);

            [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetUniformBlockIndex pglGetUniformBlockIndex;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetActiveUniformBlockiv(uint program, uint uniformBlockIndex, int pname, int* @params);

            [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetActiveUniformBlockiv pglGetActiveUniformBlockiv;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, int* length, StringBuilder uniformBlockName);

            [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetActiveUniformBlockName pglGetActiveUniformBlockName;

            [RequiredByFeature("GL_VERSION_3_1")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding);

            [RequiredByFeature("GL_VERSION_3_1")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_uniform_buffer_object", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformBlockBinding pglUniformBlockBinding;
        }
    }
}