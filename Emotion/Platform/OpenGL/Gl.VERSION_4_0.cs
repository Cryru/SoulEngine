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
        /// [GLES3.2] Gl.Get: data returns a single integer value indicating whether sample rate shading is enabled. See Gl.Enable.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_sample_shading", Api = "gl|glcore")]
        [RequiredByFeature("GL_OES_sample_shading", Api = "gles2")]
        public const int SAMPLE_SHADING = 0x8C36;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns a single floating-point value indicating the minimum sample shading fraction. See
        /// Gl.MinSampleShading.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_sample_shading", Api = "gl|glcore")]
        [RequiredByFeature("GL_OES_sample_shading", Api = "gles2")]
        public const int MIN_SAMPLE_SHADING_VALUE = 0x8C37;

        /// <summary>
        /// [GL] Value of GL_MIN_PROGRAM_TEXTURE_GATHER_OFFSET symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_gather", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_gpu_program5")]
        public const int MIN_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5E;

        /// <summary>
        /// [GL] Value of GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_gather", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_gpu_program5")]
        public const int MAX_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5F;

        /// <summary>
        /// [GL] Value of GL_TEXTURE_CUBE_MAP_ARRAY symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_internalformat_query2", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
        [RequiredByFeature("GL_EXT_sparse_texture", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
        public const int TEXTURE_CUBE_MAP_ARRAY = 0x9009;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns a single value, the name of the texture currently bound to the target
        /// Gl.TEXTURE_CUBE_MAP_ARRAY. The initial value is 0. See Gl.BindTexture.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_VERSION_4_5")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_direct_state_access", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
        public const int TEXTURE_BINDING_CUBE_MAP_ARRAY = 0x900A;

        /// <summary>
        /// [GL] Value of GL_PROXY_TEXTURE_CUBE_MAP_ARRAY symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
        public const int PROXY_TEXTURE_CUBE_MAP_ARRAY = 0x900B;

        /// <summary>
        /// [GL] Value of GL_SAMPLER_CUBE_MAP_ARRAY symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
        public const int SAMPLER_CUBE_MAP_ARRAY = 0x900C;

        /// <summary>
        /// [GL] Value of GL_SAMPLER_CUBE_MAP_ARRAY_SHADOW symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
        public const int SAMPLER_CUBE_MAP_ARRAY_SHADOW = 0x900D;

        /// <summary>
        /// [GL] Value of GL_INT_SAMPLER_CUBE_MAP_ARRAY symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
        public const int INT_SAMPLER_CUBE_MAP_ARRAY = 0x900E;

        /// <summary>
        /// [GL] Value of GL_UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_texture_cube_map_array", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_texture_cube_map_array", Api = "gles2")]
        [RequiredByFeature("GL_OES_texture_cube_map_array", Api = "gles2")]
        public const int UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900F;

        /// <summary>
        /// [GL] Value of GL_DRAW_INDIRECT_BUFFER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")] [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
        public const int DRAW_INDIRECT_BUFFER = 0x8F3F;

        /// <summary>
        /// [GL] Value of GL_DRAW_INDIRECT_BUFFER_BINDING symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")] [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
        public const int DRAW_INDIRECT_BUFFER_BINDING = 0x8F43;

        /// <summary>
        /// [GLES3.2] Gl.GetProgram: params returns the number of invocations per primitive that the geometry shader in program
        /// will
        /// execute.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_VERSION_4_6")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_gpu_shader5", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_pipeline_statistics_query", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
        public const int GEOMETRY_SHADER_INVOCATIONS = 0x887F;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum supported number of invocations per primitive of a geometry
        /// shader.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_gpu_shader5", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_geometry_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_geometry_shader", Api = "gles2")]
        public const int MAX_GEOMETRY_SHADER_INVOCATIONS = 0x8E5A;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns a single floating-point value indicating the minimum valid offset for interpolation. See
        /// Gl.terpolateAtOffset.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_gpu_shader5", Api = "gl|glcore")]
        [RequiredByFeature("GL_OES_shader_multisample_interpolation", Api = "gles2")]
        [RequiredByFeature("GL_NV_gpu_program5")]
        public const int MIN_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5B;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns a single floating-point value indicating the maximum valid offset for interpolation. See
        /// Gl.terpolateAtOffset.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_gpu_shader5", Api = "gl|glcore")]
        [RequiredByFeature("GL_OES_shader_multisample_interpolation", Api = "gles2")]
        [RequiredByFeature("GL_NV_gpu_program5")]
        public const int MAX_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5C;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns a single integer value indicating the number of subpixels bits available in the offset
        /// for interpolation. See Gl.terpolateAtOffset.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_gpu_shader5", Api = "gl|glcore")]
        [RequiredByFeature("GL_OES_shader_multisample_interpolation", Api = "gles2")]
        public const int FRAGMENT_INTERPOLATION_OFFSET_BITS = 0x8E5D;

        /// <summary>
        /// [GL] Value of GL_MAX_VERTEX_STREAMS symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader5", Api = "gl|glcore")] [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
        public const int MAX_VERTEX_STREAMS = 0x8E71;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_VEC2 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_VEC2 = 0x8FFC;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_VEC3 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_VEC3 = 0x8FFD;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_VEC4 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_VEC4 = 0x8FFE;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT2 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT2 = 0x8F46;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT3 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT3 = 0x8F47;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT4 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT4 = 0x8F48;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT2x3 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT2x3 = 0x8F49;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT2x4 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT2x4 = 0x8F4A;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT3x2 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT3x2 = 0x8F4B;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT3x4 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT3x4 = 0x8F4C;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT4x2 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT4x2 = 0x8F4D;

        /// <summary>
        /// [GL] Value of GL_DOUBLE_MAT4x3 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        [RequiredByFeature("GL_ARB_vertex_attrib_64bit", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_vertex_attrib_64bit")]
        public const int DOUBLE_MAT4x3 = 0x8F4E;

        /// <summary>
        /// [GL] Value of GL_ACTIVE_SUBROUTINES symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int ACTIVE_SUBROUTINES = 0x8DE5;

        /// <summary>
        /// [GL] Value of GL_ACTIVE_SUBROUTINE_UNIFORMS symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int ACTIVE_SUBROUTINE_UNIFORMS = 0x8DE6;

        /// <summary>
        /// [GL] Value of GL_ACTIVE_SUBROUTINE_UNIFORM_LOCATIONS symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int ACTIVE_SUBROUTINE_UNIFORM_LOCATIONS = 0x8E47;

        /// <summary>
        /// [GL] Value of GL_ACTIVE_SUBROUTINE_MAX_LENGTH symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int ACTIVE_SUBROUTINE_MAX_LENGTH = 0x8E48;

        /// <summary>
        /// [GL] Value of GL_ACTIVE_SUBROUTINE_UNIFORM_MAX_LENGTH symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int ACTIVE_SUBROUTINE_UNIFORM_MAX_LENGTH = 0x8E49;

        /// <summary>
        /// [GL] Value of GL_MAX_SUBROUTINES symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int MAX_SUBROUTINES = 0x8DE7;

        /// <summary>
        /// [GL] Value of GL_MAX_SUBROUTINE_UNIFORM_LOCATIONS symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int MAX_SUBROUTINE_UNIFORM_LOCATIONS = 0x8DE8;

        /// <summary>
        /// [GL] Value of GL_NUM_COMPATIBLE_SUBROUTINES symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int NUM_COMPATIBLE_SUBROUTINES = 0x8E4A;

        /// <summary>
        /// [GL] Value of GL_COMPATIBLE_SUBROUTINES symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_program_interface_query", Api = "gl|glcore")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public const int COMPATIBLE_SUBROUTINES = 0x8E4B;

        /// <summary>
        /// [GL] Value of GL_PATCHES symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_gpu_shader5", Api = "gl|glcore|gles2")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int PATCHES = 0x000E;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the number of vertices in an input patch. The initial value is 3. See
        /// Gl.PatchParameteri.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int PATCH_VERTICES = 0x8E72;

        /// <summary>
        /// [GL] Value of GL_PATCH_DEFAULT_INNER_LEVEL symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        public const int PATCH_DEFAULT_INNER_LEVEL = 0x8E73;

        /// <summary>
        /// [GL] Value of GL_PATCH_DEFAULT_OUTER_LEVEL symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        public const int PATCH_DEFAULT_OUTER_LEVEL = 0x8E74;

        /// <summary>
        /// [GLES3.2] Gl.GetProgram: params returns the number of vertices in the tesselation control shader output patch.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int TESS_CONTROL_OUTPUT_VERTICES = 0x8E75;

        /// <summary>
        /// [GLES3.2] Gl.GetProgram: params returns the primitive mode declared by the tesselation evaluation shader for
        /// tesselation
        /// primitive generation. This is one of Gl.QUADS, Gl.TRIANGLES, or Gl.ISOLINES.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int TESS_GEN_MODE = 0x8E76;

        /// <summary>
        /// [GLES3.2] Gl.GetProgram: params returns the spacing declared by the tesselation evaluation shader for tesselation
        /// primitive generation edge subdivision. This is one of Gl.EQUAL, Gl.FRACTIONAL_EVEN, or Gl.FRACTIONAL_ODD.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int TESS_GEN_SPACING = 0x8E77;

        /// <summary>
        /// [GLES3.2] Gl.GetProgram: params returns the vertex order declared by the tesselation evaluation shader for tesselation
        /// primitive generation. This is one of Gl.CW, or Gl.CCW.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int TESS_GEN_VERTEX_ORDER = 0x8E78;

        /// <summary>
        /// [GLES3.2] Gl.GetProgram: params returns a single boolean, the point mode declared by the tesselation evaluation shader
        /// to determine if the tesselation primitive generator emits points.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int TESS_GEN_POINT_MODE = 0x8E79;

        /// <summary>
        /// [GL] Value of GL_ISOLINES symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int ISOLINES = 0x8E7A;

        /// <summary>
        /// [GL] Value of GL_FRACTIONAL_ODD symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int FRACTIONAL_ODD = 0x8E7B;

        /// <summary>
        /// [GL] Value of GL_FRACTIONAL_EVEN symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int FRACTIONAL_EVEN = 0x8E7C;

        /// <summary>
        /// [GL] Value of GL_MAX_PATCH_VERTICES symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_PATCH_VERTICES = 0x8E7D;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns a single value, the maximum tessellation level supported by the tesselation primitive
        /// generator.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_GEN_LEVEL = 0x8E7E;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of individual floating-point, integer, or boolean values
        /// that can be held in uniform variable storage for a tesselation control shader. The value must be at least 1024. See
        /// Gl.Uniform.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E7F;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of individual floating-point, integer, or boolean values
        /// that can be held in uniform variable storage for a tesselation evaluation shader. The value must be at least 1024. See
        /// Gl.Uniform.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E80;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum supported texture image units that can be used to access texture
        /// maps from the tesselation control shader. The value may be at least 16. See Gl.ActiveTexture.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_CONTROL_TEXTURE_IMAGE_UNITS = 0x8E81;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum supported texture image units that can be used to access texture
        /// maps from the tesselation evaluation shader. The value may be at least 16. See Gl.ActiveTexture.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_EVALUATION_TEXTURE_IMAGE_UNITS = 0x8E82;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of components of outputs written by a tesselation control
        /// shader, which must be at least 128.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_CONTROL_OUTPUT_COMPONENTS = 0x8E83;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of components of per-patch outputs written by a
        /// tesselation
        /// control shader, which must be at least 128.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_PATCH_COMPONENTS = 0x8E84;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum total number of components of active outputs for all vertices
        /// written by a tesselation control shader, including per-vertex and per-patch outputs, which must be at least 2048.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_CONTROL_TOTAL_OUTPUT_COMPONENTS = 0x8E85;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of components of outputs written by a tesselation
        /// evaluation shader, which must be at least 128.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_EVALUATION_OUTPUT_COMPONENTS = 0x8E86;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of uniform blocks per tesselation control shader. The
        /// value
        /// must be at least 12. See Gl.UniformBlockBinding.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_CONTROL_UNIFORM_BLOCKS = 0x8E89;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of uniform blocks per tesselation evaluation shader. The
        /// value must be at least 12. See Gl.UniformBlockBinding.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_EVALUATION_UNIFORM_BLOCKS = 0x8E8A;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of components of inputs read by a tesselation control
        /// shader, which must be at least 128.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_CONTROL_INPUT_COMPONENTS = 0x886C;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the maximum number of components of inputs read by a tesselation evaluation
        /// shader, which must be at least 128.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_TESS_EVALUATION_INPUT_COMPONENTS = 0x886D;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the number of words for tesselation control shader uniform variables in all
        /// uniform blocks (including default). The value must be at least Gl.MAX_TESS_CONTROL_UNIFORM_COMPONENTS +
        /// Gl.MAX_UNIFORM_BLOCK_SIZE * Gl.MAX_TESS_CONTROL_UNIFORM_BLOCKS / 4. See Gl.Uniform.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_COMBINED_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E1E;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns one value, the number of words for tesselation evaluation shader uniform variables in
        /// all
        /// uniform blocks (including default). The value must be at least Gl.MAX_TESS_EVALUATION_UNIFORM_COMPONENTS +
        /// Gl.MAX_UNIFORM_BLOCK_SIZE * Gl.MAX_TESS_EVALUATION_UNIFORM_BLOCKS / 4. See Gl.Uniform.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int MAX_COMBINED_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E1F;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_REFERENCED_BY_TESS_CONTROL_SHADER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_REFERENCED_BY_TESS_CONTROL_SHADER = 0x84F0;

        /// <summary>
        /// [GL] Value of GL_UNIFORM_BLOCK_REFERENCED_BY_TESS_EVALUATION_SHADER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        public const int UNIFORM_BLOCK_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x84F1;

        /// <summary>
        /// [GL] Value of GL_TESS_EVALUATION_SHADER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int TESS_EVALUATION_SHADER = 0x8E87;

        /// <summary>
        /// [GL] Value of GL_TESS_CONTROL_SHADER symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public const int TESS_CONTROL_SHADER = 0x8E88;

        /// <summary>
        /// [GL] Value of GL_TRANSFORM_FEEDBACK symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_debug_label", Api = "gl|glcore|gles2")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public const int TRANSFORM_FEEDBACK = 0x8E22;

        /// <summary>
        /// [GL] Value of GL_TRANSFORM_FEEDBACK_BUFFER_PAUSED symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")] [RequiredByFeature("GL_NV_transform_feedback2")]
        public const int TRANSFORM_FEEDBACK_BUFFER_PAUSED = 0x8E23;

        /// <summary>
        /// [GL] Value of GL_TRANSFORM_FEEDBACK_BUFFER_ACTIVE symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")] [RequiredByFeature("GL_NV_transform_feedback2")]
        public const int TRANSFORM_FEEDBACK_BUFFER_ACTIVE = 0x8E24;

        /// <summary>
        /// [GLES3.2] Gl.Get: data returns a single value, the name of the transform feedback object currently bound to the
        /// Gl.TRANSFORM_FEEDBACK target. If no transform feedback object is bound to this target, 0 is returned. The initial value
        /// is 0. See Gl.BindTransformFeedback.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public const int TRANSFORM_FEEDBACK_BINDING = 0x8E25;

        /// <summary>
        /// [GL] Value of GL_MAX_TRANSFORM_FEEDBACK_BUFFERS symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
        public const int MAX_TRANSFORM_FEEDBACK_BUFFERS = 0x8E70;

        /// <summary>
        ///     <para>
        ///     [GL4] glMinSampleShading: specifies minimum rate at which sample shaing takes place
        ///     </para>
        ///     <para>
        ///     [GLES3.2] glMinSampleShading: specifies minimum rate at which sample shading takes place
        ///     </para>
        /// </summary>
        /// <param name="value">
        /// Specifies the rate at which samples are shaded within each covered pixel.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_sample_shading", Api = "gl|glcore")]
        [RequiredByFeature("GL_OES_sample_shading", Api = "gles2")]
        public static void MinSampleShading(float value)
        {
            Debug.Assert(Delegates.pglMinSampleShading != null, "pglMinSampleShading not implemented");
            Delegates.pglMinSampleShading(value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glBlendEquationi: Binding for glBlendEquationi.
        /// </summary>
        /// <param name="buf">
        /// A <see cref="T:uint" />.
        /// </param>
        /// <param name="mode">
        /// A <see cref="T:BlendEquationMode" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_AMD_draw_buffers_blend")]
        [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
        [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
        public static void BlendEquation(uint buf, BlendEquationMode mode)
        {
            Debug.Assert(Delegates.pglBlendEquationi != null, "pglBlendEquationi not implemented");
            Delegates.pglBlendEquationi(buf, (int) mode);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glBlendEquationSeparatei: Binding for glBlendEquationSeparatei.
        /// </summary>
        /// <param name="buf">
        /// A <see cref="T:uint" />.
        /// </param>
        /// <param name="modeRGB">
        /// A <see cref="T:BlendEquationMode" />.
        /// </param>
        /// <param name="modeAlpha">
        /// A <see cref="T:BlendEquationMode" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_AMD_draw_buffers_blend")]
        [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
        [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
        public static void BlendEquationSeparate(uint buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha)
        {
            Debug.Assert(Delegates.pglBlendEquationSeparatei != null, "pglBlendEquationSeparatei not implemented");
            Delegates.pglBlendEquationSeparatei(buf, (int) modeRGB, (int) modeAlpha);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glBlendFunci: Binding for glBlendFunci.
        /// </summary>
        /// <param name="buf">
        /// A <see cref="T:uint" />.
        /// </param>
        /// <param name="src">
        /// A <see cref="T:BlendingFactor" />.
        /// </param>
        /// <param name="dst">
        /// A <see cref="T:BlendingFactor" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_AMD_draw_buffers_blend")]
        [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
        [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
        public static void BlendFunc(uint buf, BlendingFactor src, BlendingFactor dst)
        {
            Debug.Assert(Delegates.pglBlendFunci != null, "pglBlendFunci not implemented");
            Delegates.pglBlendFunci(buf, (int) src, (int) dst);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glBlendFuncSeparatei: Binding for glBlendFuncSeparatei.
        /// </summary>
        /// <param name="buf">
        /// A <see cref="T:uint" />.
        /// </param>
        /// <param name="srcRGB">
        /// A <see cref="T:BlendingFactor" />.
        /// </param>
        /// <param name="dstRGB">
        /// A <see cref="T:BlendingFactor" />.
        /// </param>
        /// <param name="srcAlpha">
        /// A <see cref="T:BlendingFactor" />.
        /// </param>
        /// <param name="dstAlpha">
        /// A <see cref="T:BlendingFactor" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_AMD_draw_buffers_blend")]
        [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
        [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
        public static void BlendFuncSeparate(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha)
        {
            Debug.Assert(Delegates.pglBlendFuncSeparatei != null, "pglBlendFuncSeparatei not implemented");
            Delegates.pglBlendFuncSeparatei(buf, (int) srcRGB, (int) dstRGB, (int) srcAlpha, (int) dstAlpha);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glDrawArraysIndirect: render primitives from array data, taking parameters from memory
        ///     </para>
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.LINE_STRIP_ADJACENCY, Gl.LINES_ADJACENCY, Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLES,
        /// Gl.TRIANGLE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY, and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="indirect">
        /// Specifies the address of a structure containing the draw parameters.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
        [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
        public static void DrawArraysIndirect(PrimitiveType mode, IntPtr indirect)
        {
            Debug.Assert(Delegates.pglDrawArraysIndirect != null, "pglDrawArraysIndirect not implemented");
            Delegates.pglDrawArraysIndirect((int) mode, indirect);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glDrawArraysIndirect: render primitives from array data, taking parameters from memory
        ///     </para>
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.LINE_STRIP_ADJACENCY, Gl.LINES_ADJACENCY, Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLES,
        /// Gl.TRIANGLE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY, and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="indirect">
        /// Specifies the address of a structure containing the draw parameters.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
        [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
        public static void DrawArraysIndirect(PrimitiveType mode, object indirect)
        {
            GCHandle pin_indirect = GCHandle.Alloc(indirect, GCHandleType.Pinned);
            try
            {
                DrawArraysIndirect(mode, pin_indirect.AddrOfPinnedObject());
            }
            finally
            {
                pin_indirect.Free();
            }
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glDrawElementsIndirect: render indexed primitives from array data, taking parameters from memory
        ///     </para>
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.LINE_STRIP_ADJACENCY, Gl.LINES_ADJACENCY, Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLES,
        /// Gl.TRIANGLE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY, and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="type">
        /// Specifies the type of data in the buffer bound to the Gl.ELEMENT_ARRAY_BUFFER binding.
        /// </param>
        /// <param name="indirect">
        /// Specifies the address of a structure containing the draw parameters.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
        [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
        public static void DrawElementsIndirect(PrimitiveType mode, DrawElementsType type, IntPtr indirect)
        {
            Debug.Assert(Delegates.pglDrawElementsIndirect != null, "pglDrawElementsIndirect not implemented");
            Delegates.pglDrawElementsIndirect((int) mode, (int) type, indirect);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glDrawElementsIndirect: render indexed primitives from array data, taking parameters from memory
        ///     </para>
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.LINE_STRIP_ADJACENCY, Gl.LINES_ADJACENCY, Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLES,
        /// Gl.TRIANGLE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY, and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="type">
        /// Specifies the type of data in the buffer bound to the Gl.ELEMENT_ARRAY_BUFFER binding.
        /// </param>
        /// <param name="indirect">
        /// Specifies the address of a structure containing the draw parameters.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
        [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
        public static void DrawElementsIndirect(PrimitiveType mode, DrawElementsType type, object indirect)
        {
            GCHandle pin_indirect = GCHandle.Alloc(indirect, GCHandleType.Pinned);
            try
            {
                DrawElementsIndirect(mode, type, pin_indirect.AddrOfPinnedObject());
            }
            finally
            {
                pin_indirect.Free();
            }
        }

        /// <summary>
        /// [GL] glUniform1d: Binding for glUniform1d.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="x">
        /// A <see cref="T:double" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform1(int location, double x)
        {
            Debug.Assert(Delegates.pglUniform1d != null, "pglUniform1d not implemented");
            Delegates.pglUniform1d(location, x);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform2d: Binding for glUniform2d.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="x">
        /// A <see cref="T:double" />.
        /// </param>
        /// <param name="y">
        /// A <see cref="T:double" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform2(int location, double x, double y)
        {
            Debug.Assert(Delegates.pglUniform2d != null, "pglUniform2d not implemented");
            Delegates.pglUniform2d(location, x, y);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform3d: Binding for glUniform3d.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="x">
        /// A <see cref="T:double" />.
        /// </param>
        /// <param name="y">
        /// A <see cref="T:double" />.
        /// </param>
        /// <param name="z">
        /// A <see cref="T:double" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform3(int location, double x, double y, double z)
        {
            Debug.Assert(Delegates.pglUniform3d != null, "pglUniform3d not implemented");
            Delegates.pglUniform3d(location, x, y, z);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform4d: Binding for glUniform4d.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="x">
        /// A <see cref="T:double" />.
        /// </param>
        /// <param name="y">
        /// A <see cref="T:double" />.
        /// </param>
        /// <param name="z">
        /// A <see cref="T:double" />.
        /// </param>
        /// <param name="w">
        /// A <see cref="T:double" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform4(int location, double x, double y, double z, double w)
        {
            Debug.Assert(Delegates.pglUniform4d != null, "pglUniform4d not implemented");
            Delegates.pglUniform4d(location, x, y, z, w);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform1dv: Binding for glUniform1dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform1(int location, double[] value)
        {
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniform1dv != null, "pglUniform1dv not implemented");
                    Delegates.pglUniform1dv(location, value.Length, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform1dv: Binding for glUniform1dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void Uniform1(int location, int count, double* value)
        {
            Debug.Assert(Delegates.pglUniform1dv != null, "pglUniform1dv not implemented");
            Delegates.pglUniform1dv(location, count, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform1dv: Binding for glUniform1dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform1d<T>(int location, int count, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniform1dv != null, "pglUniform1dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniform1dv(location, count, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform2dv: Binding for glUniform2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform2(int location, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 2 == 0, "empty or not multiple of 2");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniform2dv != null, "pglUniform2dv not implemented");
                    Delegates.pglUniform2dv(location, value.Length / 2, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform2dv: Binding for glUniform2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void Uniform2(int location, int count, double* value)
        {
            Debug.Assert(Delegates.pglUniform2dv != null, "pglUniform2dv not implemented");
            Delegates.pglUniform2dv(location, count, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform2dv: Binding for glUniform2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform2d<T>(int location, int count, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniform2dv != null, "pglUniform2dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniform2dv(location, count, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform3dv: Binding for glUniform3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform3(int location, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 3 == 0, "empty or not multiple of 3");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniform3dv != null, "pglUniform3dv not implemented");
                    Delegates.pglUniform3dv(location, value.Length / 3, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform3dv: Binding for glUniform3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void Uniform3(int location, int count, double* value)
        {
            Debug.Assert(Delegates.pglUniform3dv != null, "pglUniform3dv not implemented");
            Delegates.pglUniform3dv(location, count, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform3dv: Binding for glUniform3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform3d<T>(int location, int count, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniform3dv != null, "pglUniform3dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniform3dv(location, count, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform4dv: Binding for glUniform4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform4(int location, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 4 == 0, "empty or not multiple of 4");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniform4dv != null, "pglUniform4dv not implemented");
                    Delegates.pglUniform4dv(location, value.Length / 4, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform4dv: Binding for glUniform4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void Uniform4(int location, int count, double* value)
        {
            Debug.Assert(Delegates.pglUniform4dv != null, "pglUniform4dv not implemented");
            Delegates.pglUniform4dv(location, count, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniform4dv: Binding for glUniform4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void Uniform4d<T>(int location, int count, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniform4dv != null, "pglUniform4dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniform4dv(location, count, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2dv: Binding for glUniformMatrix2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix2(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 4 == 0, "empty or not multiple of 4");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix2dv != null, "pglUniformMatrix2dv not implemented");
                    Delegates.pglUniformMatrix2dv(location, value.Length / 4, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2dv: Binding for glUniformMatrix2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix2(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix2dv != null, "pglUniformMatrix2dv not implemented");
            Delegates.pglUniformMatrix2dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2dv: Binding for glUniformMatrix2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix2d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix2dv != null, "pglUniformMatrix2dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix2dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3dv: Binding for glUniformMatrix3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix3(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 9 == 0, "empty or not multiple of 9");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix3dv != null, "pglUniformMatrix3dv not implemented");
                    Delegates.pglUniformMatrix3dv(location, value.Length / 9, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3dv: Binding for glUniformMatrix3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix3(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix3dv != null, "pglUniformMatrix3dv not implemented");
            Delegates.pglUniformMatrix3dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3dv: Binding for glUniformMatrix3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix3d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix3dv != null, "pglUniformMatrix3dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix3dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4dv: Binding for glUniformMatrix4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix4(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 16 == 0, "empty or not multiple of 16");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix4dv != null, "pglUniformMatrix4dv not implemented");
                    Delegates.pglUniformMatrix4dv(location, value.Length / 16, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4dv: Binding for glUniformMatrix4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix4(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix4dv != null, "pglUniformMatrix4dv not implemented");
            Delegates.pglUniformMatrix4dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4dv: Binding for glUniformMatrix4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix4d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix4dv != null, "pglUniformMatrix4dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix4dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2x3dv: Binding for glUniformMatrix2x3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix2x3(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 6 == 0, "empty or not multiple of 6");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix2x3dv != null, "pglUniformMatrix2x3dv not implemented");
                    Delegates.pglUniformMatrix2x3dv(location, value.Length / 6, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2x3dv: Binding for glUniformMatrix2x3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix2x3(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix2x3dv != null, "pglUniformMatrix2x3dv not implemented");
            Delegates.pglUniformMatrix2x3dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2x3dv: Binding for glUniformMatrix2x3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix2x3d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix2x3dv != null, "pglUniformMatrix2x3dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix2x3dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2x4dv: Binding for glUniformMatrix2x4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix2x4(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 8 == 0, "empty or not multiple of 8");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix2x4dv != null, "pglUniformMatrix2x4dv not implemented");
                    Delegates.pglUniformMatrix2x4dv(location, value.Length / 8, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2x4dv: Binding for glUniformMatrix2x4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix2x4(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix2x4dv != null, "pglUniformMatrix2x4dv not implemented");
            Delegates.pglUniformMatrix2x4dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix2x4dv: Binding for glUniformMatrix2x4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix2x4d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix2x4dv != null, "pglUniformMatrix2x4dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix2x4dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3x2dv: Binding for glUniformMatrix3x2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix3x2(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 6 == 0, "empty or not multiple of 6");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix3x2dv != null, "pglUniformMatrix3x2dv not implemented");
                    Delegates.pglUniformMatrix3x2dv(location, value.Length / 6, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3x2dv: Binding for glUniformMatrix3x2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix3x2(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix3x2dv != null, "pglUniformMatrix3x2dv not implemented");
            Delegates.pglUniformMatrix3x2dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3x2dv: Binding for glUniformMatrix3x2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix3x2d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix3x2dv != null, "pglUniformMatrix3x2dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix3x2dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3x4dv: Binding for glUniformMatrix3x4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix3x4(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 12 == 0, "empty or not multiple of 12");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix3x4dv != null, "pglUniformMatrix3x4dv not implemented");
                    Delegates.pglUniformMatrix3x4dv(location, value.Length / 12, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3x4dv: Binding for glUniformMatrix3x4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix3x4(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix3x4dv != null, "pglUniformMatrix3x4dv not implemented");
            Delegates.pglUniformMatrix3x4dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix3x4dv: Binding for glUniformMatrix3x4dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix3x4d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix3x4dv != null, "pglUniformMatrix3x4dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix3x4dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4x2dv: Binding for glUniformMatrix4x2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix4x2(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 8 == 0, "empty or not multiple of 8");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix4x2dv != null, "pglUniformMatrix4x2dv not implemented");
                    Delegates.pglUniformMatrix4x2dv(location, value.Length / 8, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4x2dv: Binding for glUniformMatrix4x2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix4x2(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix4x2dv != null, "pglUniformMatrix4x2dv not implemented");
            Delegates.pglUniformMatrix4x2dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4x2dv: Binding for glUniformMatrix4x2dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix4x2d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix4x2dv != null, "pglUniformMatrix4x2dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix4x2dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4x3dv: Binding for glUniformMatrix4x3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix4x3(int location, bool transpose, double[] value)
        {
            Debug.Assert(value.Length > 0 && value.Length % 12 == 0, "empty or not multiple of 12");
            unsafe
            {
                fixed (double* p_value = value)
                {
                    Debug.Assert(Delegates.pglUniformMatrix4x3dv != null, "pglUniformMatrix4x3dv not implemented");
                    Delegates.pglUniformMatrix4x3dv(location, value.Length / 12, transpose, p_value);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4x3dv: Binding for glUniformMatrix4x3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:double*" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void UniformMatrix4x3(int location, int count, bool transpose, double* value)
        {
            Debug.Assert(Delegates.pglUniformMatrix4x3dv != null, "pglUniformMatrix4x3dv not implemented");
            Delegates.pglUniformMatrix4x3dv(location, count, transpose, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL] glUniformMatrix4x3dv: Binding for glUniformMatrix4x3dv.
        /// </summary>
        /// <param name="location">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="count">
        /// A <see cref="T:int" />.
        /// </param>
        /// <param name="transpose">
        /// A <see cref="T:bool" />.
        /// </param>
        /// <param name="value">
        /// A <see cref="T:T" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void UniformMatrix4x3d<T>(int location, int count, bool transpose, T value) where T : struct
        {
            Debug.Assert(Delegates.pglUniformMatrix4x3dv != null, "pglUniformMatrix4x3dv not implemented");
            unsafe
            {
                TypedReference refValue = __makeref(value);
                IntPtr refValuePtr = *(IntPtr*) (&refValue);

                Delegates.pglUniformMatrix4x3dv(location, count, transpose, (double*) refValuePtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetUniformdv: Returns the value of a uniform variable
        /// </summary>
        /// <param name="program">
        /// Specifies the program object to be queried.
        /// </param>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be queried.
        /// </param>
        /// <param name="params">
        /// Returns the value of the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void GetUniform(uint program, int location, [Out] double[] @params)
        {
            unsafe
            {
                fixed (double* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetUniformdv != null, "pglGetUniformdv not implemented");
                    Delegates.pglGetUniformdv(program, location, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetUniformdv: Returns the value of a uniform variable
        /// </summary>
        /// <param name="program">
        /// Specifies the program object to be queried.
        /// </param>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be queried.
        /// </param>
        /// <param name="params">
        /// Returns the value of the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static unsafe void GetUniform(uint program, int location, [Out] double* @params)
        {
            Debug.Assert(Delegates.pglGetUniformdv != null, "pglGetUniformdv not implemented");
            Delegates.pglGetUniformdv(program, location, @params);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetUniformdv: Returns the value of a uniform variable
        /// </summary>
        /// <param name="program">
        /// Specifies the program object to be queried.
        /// </param>
        /// <param name="location">
        /// Specifies the location of the uniform variable to be queried.
        /// </param>
        /// <param name="params">
        /// Returns the value of the specified uniform variable.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
        public static void GetUniformd<T>(uint program, int location, out T @params) where T : struct
        {
            Debug.Assert(Delegates.pglGetUniformdv != null, "pglGetUniformdv not implemented");
            @params = default;
            unsafe
            {
                TypedReference refParams = __makeref(@params);
                IntPtr refParamsPtr = *(IntPtr*) (&refParams);

                Delegates.pglGetUniformdv(program, location, (double*) refParamsPtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetSubroutineUniformLocation: retrieve the location of a subroutine uniform of a given shader stage within a
        /// program
        /// </summary>
        /// <param name="program">
        /// Specifies the name of the program containing shader stage.
        /// </param>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for subroutine uniform index. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="name">
        /// Specifies the name of the subroutine uniform whose index to query.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static int GetSubroutineUniformLocation(uint program, ShaderType shadertype, string name)
        {
            int retValue;

            Debug.Assert(Delegates.pglGetSubroutineUniformLocation != null, "pglGetSubroutineUniformLocation not implemented");
            retValue = Delegates.pglGetSubroutineUniformLocation(program, (int) shadertype, name);
            DebugCheckErrors(retValue);

            return retValue;
        }

        /// <summary>
        /// [GL4] glGetSubroutineIndex: retrieve the index of a subroutine uniform of a given shader stage within a program
        /// </summary>
        /// <param name="program">
        /// Specifies the name of the program containing shader stage.
        /// </param>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for subroutine uniform index. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="name">
        /// Specifies the name of the subroutine uniform whose index to query.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static uint GetSubroutineIndex(uint program, ShaderType shadertype, string name)
        {
            uint retValue;

            Debug.Assert(Delegates.pglGetSubroutineIndex != null, "pglGetSubroutineIndex not implemented");
            retValue = Delegates.pglGetSubroutineIndex(program, (int) shadertype, name);
            DebugCheckErrors(retValue);

            return retValue;
        }

        /// <summary>
        /// [GL4] glGetActiveSubroutineUniformiv: query a property of an active shader subroutine uniform
        /// </summary>
        /// <param name="program">
        /// Specifies the name of the program containing the subroutine.
        /// </param>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for the subroutine parameter. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="index">
        /// Specifies the index of the shader subroutine uniform.
        /// </param>
        /// <param name="pname">
        /// Specifies the parameter of the shader subroutine uniform to query. <paramref name="pname" /> must be
        /// Gl.NUM_COMPATIBLE_SUBROUTINES, Gl.COMPATIBLE_SUBROUTINES, Gl.UNIFORM_SIZE or Gl.UNIFORM_NAME_LENGTH.
        /// </param>
        /// <param name="values">
        /// Specifies the address of a into which the queried value or values will be placed.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static void GetActiveSubroutineUniform(uint program, ShaderType shadertype, uint index, SubroutineParameterName pname, [Out] int[] values)
        {
            unsafe
            {
                fixed (int* p_values = values)
                {
                    Debug.Assert(Delegates.pglGetActiveSubroutineUniformiv != null, "pglGetActiveSubroutineUniformiv not implemented");
                    Delegates.pglGetActiveSubroutineUniformiv(program, (int) shadertype, index, (int) pname, p_values);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetActiveSubroutineUniformiv: query a property of an active shader subroutine uniform
        /// </summary>
        /// <param name="program">
        /// Specifies the name of the program containing the subroutine.
        /// </param>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for the subroutine parameter. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="index">
        /// Specifies the index of the shader subroutine uniform.
        /// </param>
        /// <param name="pname">
        /// Specifies the parameter of the shader subroutine uniform to query. <paramref name="pname" /> must be
        /// Gl.NUM_COMPATIBLE_SUBROUTINES, Gl.COMPATIBLE_SUBROUTINES, Gl.UNIFORM_SIZE or Gl.UNIFORM_NAME_LENGTH.
        /// </param>
        /// <param name="values">
        /// Specifies the address of a into which the queried value or values will be placed.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static void GetActiveSubroutineUniform(uint program, ShaderType shadertype, uint index, SubroutineParameterName pname, out int values)
        {
            unsafe
            {
                fixed (int* p_values = &values)
                {
                    Debug.Assert(Delegates.pglGetActiveSubroutineUniformiv != null, "pglGetActiveSubroutineUniformiv not implemented");
                    Delegates.pglGetActiveSubroutineUniformiv(program, (int) shadertype, index, (int) pname, p_values);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetActiveSubroutineUniformName: query the name of an active shader subroutine uniform
        /// </summary>
        /// <param name="program">
        /// Specifies the name of the program containing the subroutine.
        /// </param>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for the subroutine parameter. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="index">
        /// Specifies the index of the shader subroutine uniform.
        /// </param>
        /// <param name="bufsize">
        /// Specifies the size of the buffer whose address is given in <paramref name="name" />.
        /// </param>
        /// <param name="length">
        /// Specifies the address of a variable into which is written the number of characters copied into <paramref name="name" />
        /// .
        /// </param>
        /// <param name="name">
        /// Specifies the address of a buffer that will receive the name of the specified shader subroutine uniform.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static void GetActiveSubroutineUniformName(uint program, ShaderType shadertype, uint index, int bufsize, out int length, StringBuilder name)
        {
            unsafe
            {
                fixed (int* p_length = &length)
                {
                    Debug.Assert(Delegates.pglGetActiveSubroutineUniformName != null, "pglGetActiveSubroutineUniformName not implemented");
                    Delegates.pglGetActiveSubroutineUniformName(program, (int) shadertype, index, bufsize, p_length, name);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetActiveSubroutineName: query the name of an active shader subroutine
        /// </summary>
        /// <param name="program">
        /// Specifies the name of the program containing the subroutine.
        /// </param>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query the subroutine name.
        /// </param>
        /// <param name="index">
        /// Specifies the index of the shader subroutine uniform.
        /// </param>
        /// <param name="bufsize">
        /// Specifies the size of the buffer whose address is given in <paramref name="name" />.
        /// </param>
        /// <param name="length">
        /// Specifies the address of a variable which is to receive the length of the shader subroutine uniform name.
        /// </param>
        /// <param name="name">
        /// Specifies the address of an array into which the name of the shader subroutine uniform will be written.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static void GetActiveSubroutineName(uint program, ShaderType shadertype, uint index, int bufsize, out int length, StringBuilder name)
        {
            unsafe
            {
                fixed (int* p_length = &length)
                {
                    Debug.Assert(Delegates.pglGetActiveSubroutineName != null, "pglGetActiveSubroutineName not implemented");
                    Delegates.pglGetActiveSubroutineName(program, (int) shadertype, index, bufsize, p_length, name);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glUniformSubroutinesuiv: load active subroutine uniforms
        /// </summary>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for subroutine uniform index. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="count">
        /// Specifies the number of uniform indices stored in <paramref name="indices" />.
        /// </param>
        /// <param name="indices">
        /// Specifies the address of an array holding the indices to load into the shader subroutine variables.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static void UniformSubroutines(ShaderType shadertype, int count, uint[] indices)
        {
            unsafe
            {
                fixed (uint* p_indices = indices)
                {
                    Debug.Assert(Delegates.pglUniformSubroutinesuiv != null, "pglUniformSubroutinesuiv not implemented");
                    Delegates.pglUniformSubroutinesuiv((int) shadertype, count, p_indices);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glUniformSubroutinesuiv: load active subroutine uniforms
        /// </summary>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for subroutine uniform index. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="indices">
        /// Specifies the address of an array holding the indices to load into the shader subroutine variables.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static void UniformSubroutines(ShaderType shadertype, uint[] indices)
        {
            unsafe
            {
                fixed (uint* p_indices = indices)
                {
                    Debug.Assert(Delegates.pglUniformSubroutinesuiv != null, "pglUniformSubroutinesuiv not implemented");
                    Delegates.pglUniformSubroutinesuiv((int) shadertype, indices.Length, p_indices);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetUniformSubroutineuiv: retrieve the value of a subroutine uniform of a given shader stage of the current
        /// program
        /// </summary>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for subroutine uniform index. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="location">
        /// Specifies the location of the subroutine uniform.
        /// </param>
        /// <param name="params">
        /// A <see cref="T:uint" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static void GetUniformSubroutine(ShaderType shadertype, int location, out uint @params)
        {
            unsafe
            {
                fixed (uint* p_params = &@params)
                {
                    Debug.Assert(Delegates.pglGetUniformSubroutineuiv != null, "pglGetUniformSubroutineuiv not implemented");
                    Delegates.pglGetUniformSubroutineuiv((int) shadertype, location, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetProgramStageiv: retrieve properties of a program object corresponding to a specified shader stage
        /// </summary>
        /// <param name="program">
        /// Specifies the name of the program containing shader stage.
        /// </param>
        /// <param name="shadertype">
        /// Specifies the shader stage from which to query for the subroutine parameter. <paramref name="shadertype" /> must be one
        /// of Gl.VERTEX_SHADER, Gl.TESS_CONTROL_SHADER, Gl.TESS_EVALUATION_SHADER, Gl.GEOMETRY_SHADER or Gl.FRAGMENT_SHADER.
        /// </param>
        /// <param name="pname">
        /// Specifies the parameter of the shader to query. <paramref name="pname" /> must be Gl.ACTIVE_SUBROUTINE_UNIFORMS,
        /// Gl.ACTIVE_SUBROUTINE_UNIFORM_LOCATIONS, Gl.ACTIVE_SUBROUTINES, Gl.ACTIVE_SUBROUTINE_UNIFORM_MAX_LENGTH, or
        /// Gl.ACTIVE_SUBROUTINE_MAX_LENGTH.
        /// </param>
        /// <param name="values">
        /// Specifies the address of a variable into which the queried value or values will be placed.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
        public static void GetProgramStage(uint program, ShaderType shadertype, ProgramStagePName pname, out int values)
        {
            unsafe
            {
                fixed (int* p_values = &values)
                {
                    Debug.Assert(Delegates.pglGetProgramStageiv != null, "pglGetProgramStageiv not implemented");
                    Delegates.pglGetProgramStageiv(program, (int) shadertype, (int) pname, p_values);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glPatchParameteri: specifies the parameters for patch primitives
        ///     </para>
        /// </summary>
        /// <param name="pname">
        /// Specifies the name of the parameter to set. The symbolc constants Gl.PATCH_VERTICES, Gl.PATCH_DEFAULT_OUTER_LEVEL, and
        /// Gl.PATCH_DEFAULT_INNER_LEVEL are accepted.
        /// </param>
        /// <param name="value">
        /// Specifies the new value for the parameter given by <paramref name="pname" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
        [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
        public static void PatchParameter(PatchParameterName pname, int value)
        {
            Debug.Assert(Delegates.pglPatchParameteri != null, "pglPatchParameteri not implemented");
            Delegates.pglPatchParameteri((int) pname, value);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glPatchParameterfv: specifies the parameters for patch primitives
        /// </summary>
        /// <param name="pname">
        /// Specifies the name of the parameter to set. The symbolc constants Gl.PATCH_VERTICES, Gl.PATCH_DEFAULT_OUTER_LEVEL, and
        /// Gl.PATCH_DEFAULT_INNER_LEVEL are accepted.
        /// </param>
        /// <param name="values">
        /// Specifies the address of an array containing the new values for the parameter given by <paramref name="pname" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
        public static void PatchParameter(PatchParameterName pname, float[] values)
        {
            unsafe
            {
                fixed (float* p_values = values)
                {
                    Debug.Assert(Delegates.pglPatchParameterfv != null, "pglPatchParameterfv not implemented");
                    Delegates.pglPatchParameterfv((int) pname, p_values);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glBindTransformFeedback: bind a transform feedback object
        ///     </para>
        /// </summary>
        /// <param name="target">
        /// Specifies the target to which to bind the transform feedback object <paramref name="id" />. <paramref name="target" />
        /// must be Gl.TRANSFORM_FEEDBACK.
        /// </param>
        /// <param name="id">
        /// Specifies the name of a transform feedback object reserved by glGenTransformFeedbacks.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        public static void BindTransformFeedback(TransformFeedbackTarget target, uint id)
        {
            Debug.Assert(Delegates.pglBindTransformFeedback != null, "pglBindTransformFeedback not implemented");
            Delegates.pglBindTransformFeedback((int) target, id);
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glDeleteTransformFeedbacks: delete transform feedback objects
        ///     </para>
        /// </summary>
        /// <param name="ids">
        /// Specifies an array of names of transform feedback objects to delete.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public static void DeleteTransformFeedbacks(params uint[] ids)
        {
            unsafe
            {
                fixed (uint* p_ids = ids)
                {
                    Debug.Assert(Delegates.pglDeleteTransformFeedbacks != null, "pglDeleteTransformFeedbacks not implemented");
                    Delegates.pglDeleteTransformFeedbacks(ids.Length, p_ids);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGenTransformFeedbacks: reserve transform feedback object names
        ///     </para>
        /// </summary>
        /// <param name="ids">
        /// Specifies an array of into which the reserved names will be written.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public static void GenTransformFeedbacks(uint[] ids)
        {
            unsafe
            {
                fixed (uint* p_ids = ids)
                {
                    Debug.Assert(Delegates.pglGenTransformFeedbacks != null, "pglGenTransformFeedbacks not implemented");
                    Delegates.pglGenTransformFeedbacks(ids.Length, p_ids);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glGenTransformFeedbacks: reserve transform feedback object names
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public static uint GenTransformFeedback()
        {
            uint retValue;
            unsafe
            {
                Delegates.pglGenTransformFeedbacks(1, &retValue);
            }

            DebugCheckErrors(null);
            return retValue;
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glIsTransformFeedback: determine if a name corresponds to a transform feedback object
        ///     </para>
        /// </summary>
        /// <param name="id">
        /// Specifies a value that may be the name of a transform feedback object.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public static bool IsTransformFeedback(uint id)
        {
            bool retValue;

            Debug.Assert(Delegates.pglIsTransformFeedback != null, "pglIsTransformFeedback not implemented");
            retValue = Delegates.pglIsTransformFeedback(id);
            DebugCheckErrors(retValue);

            return retValue;
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glPauseTransformFeedback: pause transform feedback operations
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public static void PauseTransformFeedback()
        {
            Debug.Assert(Delegates.pglPauseTransformFeedback != null, "pglPauseTransformFeedback not implemented");
            Delegates.pglPauseTransformFeedback();
            DebugCheckErrors(null);
        }

        /// <summary>
        ///     <para>
        ///     [GL4|GLES3.2] glResumeTransformFeedback: resume transform feedback operations
        ///     </para>
        /// </summary>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public static void ResumeTransformFeedback()
        {
            Debug.Assert(Delegates.pglResumeTransformFeedback != null, "pglResumeTransformFeedback not implemented");
            Delegates.pglResumeTransformFeedback();
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glDrawTransformFeedback: render primitives using a count derived from a transform feedback object
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.LINE_STRIP_ADJACENCY, Gl.LINES_ADJACENCY, Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLES,
        /// Gl.TRIANGLE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY, and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="id">
        /// Specifies the name of a transform feedback object from which to retrieve a primitive count.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
        [RequiredByFeature("GL_EXT_draw_transform_feedback", Api = "gles2")]
        [RequiredByFeature("GL_NV_transform_feedback2")]
        public static void DrawTransformFeedback(PrimitiveType mode, uint id)
        {
            Debug.Assert(Delegates.pglDrawTransformFeedback != null, "pglDrawTransformFeedback not implemented");
            Delegates.pglDrawTransformFeedback((int) mode, id);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glDrawTransformFeedbackStream: render primitives using a count derived from a specifed stream of a transform
        /// feedback object
        /// </summary>
        /// <param name="mode">
        /// Specifies what kind of primitives to render. Symbolic constants Gl.POINTS, Gl.LINE_STRIP, Gl.LINE_LOOP, Gl.LINES,
        /// Gl.LINE_STRIP_ADJACENCY, Gl.LINES_ADJACENCY, Gl.TRIANGLE_STRIP, Gl.TRIANGLE_FAN, Gl.TRIANGLES,
        /// Gl.TRIANGLE_STRIP_ADJACENCY, Gl.TRIANGLES_ADJACENCY, and Gl.PATCHES are accepted.
        /// </param>
        /// <param name="id">
        /// Specifies the name of a transform feedback object from which to retrieve a primitive count.
        /// </param>
        /// <param name="stream">
        /// Specifies the index of the transform feedback stream from which to retrieve a primitive count.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
        public static void DrawTransformFeedbackStream(PrimitiveType mode, uint id, uint stream)
        {
            Debug.Assert(Delegates.pglDrawTransformFeedbackStream != null, "pglDrawTransformFeedbackStream not implemented");
            Delegates.pglDrawTransformFeedbackStream((int) mode, id, stream);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glBeginQueryIndexed: delimit the boundaries of a query object on an indexed target
        /// </summary>
        /// <param name="target">
        /// Specifies the target type of query object established between Gl.BeginQueryIndexed and the subsequent
        /// Gl.EndQueryIndexed. The symbolic constant must be one of Gl.SAMPLES_PASSED, Gl.ANY_SAMPLES_PASSED,
        /// Gl.PRIMITIVES_GENERATED, Gl.TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or Gl.TIME_ELAPSED.
        /// </param>
        /// <param name="index">
        /// Specifies the index of the query target upon which to begin the query.
        /// </param>
        /// <param name="id">
        /// Specifies the name of a query object.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
        public static void BeginQueryIndexed(QueryTarget target, uint index, uint id)
        {
            Debug.Assert(Delegates.pglBeginQueryIndexed != null, "pglBeginQueryIndexed not implemented");
            Delegates.pglBeginQueryIndexed((int) target, index, id);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glEndQueryIndexed: delimit the boundaries of a query object on an indexed target
        /// </summary>
        /// <param name="target">
        /// Specifies the target type of query object established between Gl.BeginQueryIndexed and the subsequent
        /// Gl.EndQueryIndexed. The symbolic constant must be one of Gl.SAMPLES_PASSED, Gl.ANY_SAMPLES_PASSED,
        /// Gl.PRIMITIVES_GENERATED, Gl.TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, or Gl.TIME_ELAPSED.
        /// </param>
        /// <param name="index">
        /// Specifies the index of the query target upon which to begin the query.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
        public static void EndQueryIndexed(QueryTarget target, uint index)
        {
            Debug.Assert(Delegates.pglEndQueryIndexed != null, "pglEndQueryIndexed not implemented");
            Delegates.pglEndQueryIndexed((int) target, index);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GL4] glGetQueryIndexediv: return parameters of an indexed query object target
        /// </summary>
        /// <param name="target">
        /// Specifies a query object target. Must be Gl.SAMPLES_PASSED, Gl.ANY_SAMPLES_PASSED,
        /// Gl.ANY_SAMPLES_PASSED_CONSERVATIVEGl.PRIMITIVES_GENERATED, Gl.TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN, Gl.TIME_ELAPSED,
        /// or
        /// Gl.TIMESTAMP.
        /// </param>
        /// <param name="index">
        /// Specifies the index of the query object target.
        /// </param>
        /// <param name="pname">
        /// Specifies the symbolic name of a query object target parameter. Accepted values are Gl.CURRENT_QUERY or
        /// Gl.QUERY_COUNTER_BITS.
        /// </param>
        /// <param name="params">
        /// Returns the requested data.
        /// </param>
        [RequiredByFeature("GL_VERSION_4_0")]
        [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
        public static void GetQueryIndexed(QueryTarget target, uint index, QueryParameterName pname, [Out] int[] @params)
        {
            unsafe
            {
                fixed (int* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetQueryIndexediv != null, "pglGetQueryIndexediv not implemented");
                    Delegates.pglGetQueryIndexediv((int) target, index, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        internal static unsafe partial class Delegates
        {
            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_ARB_sample_shading", Api = "gl|glcore")]
            [RequiredByFeature("GL_OES_sample_shading", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glMinSampleShading(float value);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_ARB_sample_shading", Api = "gl|glcore", EntryPoint = "glMinSampleShadingARB")]
            [RequiredByFeature("GL_OES_sample_shading", Api = "gles2", EntryPoint = "glMinSampleShadingOES")]
            [ThreadStatic]
            internal static glMinSampleShading pglMinSampleShading;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_AMD_draw_buffers_blend")]
            [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
            [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glBlendEquationi(uint buf, int mode);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_AMD_draw_buffers_blend", EntryPoint = "glBlendEquationIndexedAMD")]
            [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore", EntryPoint = "glBlendEquationiARB")]
            [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2", EntryPoint = "glBlendEquationiEXT")]
            [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2", EntryPoint = "glBlendEquationiOES")]
            [ThreadStatic]
            internal static glBlendEquationi pglBlendEquationi;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_AMD_draw_buffers_blend")]
            [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
            [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glBlendEquationSeparatei(uint buf, int modeRGB, int modeAlpha);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_AMD_draw_buffers_blend", EntryPoint = "glBlendEquationSeparateIndexedAMD")]
            [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore", EntryPoint = "glBlendEquationSeparateiARB")]
            [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2", EntryPoint = "glBlendEquationSeparateiEXT")]
            [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2", EntryPoint = "glBlendEquationSeparateiOES")]
            [ThreadStatic]
            internal static glBlendEquationSeparatei pglBlendEquationSeparatei;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_AMD_draw_buffers_blend")]
            [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
            [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glBlendFunci(uint buf, int src, int dst);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_AMD_draw_buffers_blend", EntryPoint = "glBlendFuncIndexedAMD")]
            [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore", EntryPoint = "glBlendFunciARB")]
            [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2", EntryPoint = "glBlendFunciEXT")]
            [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2", EntryPoint = "glBlendFunciOES")]
            [ThreadStatic]
            internal static glBlendFunci pglBlendFunci;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_AMD_draw_buffers_blend")]
            [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2")]
            [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glBlendFuncSeparatei(uint buf, int srcRGB, int dstRGB, int srcAlpha, int dstAlpha);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_AMD_draw_buffers_blend", EntryPoint = "glBlendFuncSeparateIndexedAMD")]
            [RequiredByFeature("GL_ARB_draw_buffers_blend", Api = "gl|glcore", EntryPoint = "glBlendFuncSeparateiARB")]
            [RequiredByFeature("GL_EXT_draw_buffers_indexed", Api = "gles2", EntryPoint = "glBlendFuncSeparateiEXT")]
            [RequiredByFeature("GL_OES_draw_buffers_indexed", Api = "gles2", EntryPoint = "glBlendFuncSeparateiOES")]
            [ThreadStatic]
            internal static glBlendFuncSeparatei pglBlendFuncSeparatei;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
            [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glDrawArraysIndirect(int mode, IntPtr indirect);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")] [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")] [ThreadStatic]
            internal static glDrawArraysIndirect pglDrawArraysIndirect;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")]
            [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glDrawElementsIndirect(int mode, int type, IntPtr indirect);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ES_VERSION_3_1", Api = "gles2")] [RequiredByFeature("GL_ARB_draw_indirect", Api = "gl|glcore")] [ThreadStatic]
            internal static glDrawElementsIndirect pglDrawElementsIndirect;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniform1d(int location, double x);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniform1d pglUniform1d;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniform2d(int location, double x, double y);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniform2d pglUniform2d;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniform3d(int location, double x, double y, double z);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniform3d pglUniform3d;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniform4d(int location, double x, double y, double z, double w);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniform4d pglUniform4d;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniform1dv(int location, int count, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniform1dv pglUniform1dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniform2dv(int location, int count, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniform2dv pglUniform2dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniform3dv(int location, int count, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniform3dv pglUniform3dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniform4dv(int location, int count, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniform4dv pglUniform4dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix2dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix2dv pglUniformMatrix2dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix3dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix3dv pglUniformMatrix3dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix4dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix4dv pglUniformMatrix4dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix2x3dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix2x3dv pglUniformMatrix2x3dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix2x4dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix2x4dv pglUniformMatrix2x4dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix3x2dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix3x2dv pglUniformMatrix3x2dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix3x4dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix3x4dv pglUniformMatrix3x4dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix4x2dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix4x2dv pglUniformMatrix4x2dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformMatrix4x3dv(int location, int count, [MarshalAs(UnmanagedType.I1)] bool transpose, double* value);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformMatrix4x3dv pglUniformMatrix4x3dv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetUniformdv(uint program, int location, double* @params);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_gpu_shader_fp64", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetUniformdv pglGetUniformdv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate int glGetSubroutineUniformLocation(uint program, int shadertype, string name);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetSubroutineUniformLocation pglGetSubroutineUniformLocation;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate uint glGetSubroutineIndex(uint program, int shadertype, string name);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetSubroutineIndex pglGetSubroutineIndex;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetActiveSubroutineUniformiv(uint program, int shadertype, uint index, int pname, int* values);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetActiveSubroutineUniformiv pglGetActiveSubroutineUniformiv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetActiveSubroutineUniformName(uint program, int shadertype, uint index, int bufsize, int* length, StringBuilder name);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetActiveSubroutineUniformName pglGetActiveSubroutineUniformName;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetActiveSubroutineName(uint program, int shadertype, uint index, int bufsize, int* length, StringBuilder name);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetActiveSubroutineName pglGetActiveSubroutineName;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glUniformSubroutinesuiv(int shadertype, int count, uint* indices);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")] [ThreadStatic]
            internal static glUniformSubroutinesuiv pglUniformSubroutinesuiv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetUniformSubroutineuiv(int shadertype, int location, uint* @params);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetUniformSubroutineuiv pglGetUniformSubroutineuiv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetProgramStageiv(uint program, int shadertype, int pname, int* values);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_shader_subroutine", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetProgramStageiv pglGetProgramStageiv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2")]
            [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glPatchParameteri(int pname, int value);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_2", Api = "gles2")]
            [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_tessellation_shader", Api = "gles2", EntryPoint = "glPatchParameteriEXT")]
            [RequiredByFeature("GL_OES_tessellation_shader", Api = "gles2", EntryPoint = "glPatchParameteriOES")]
            [ThreadStatic]
            internal static glPatchParameteri pglPatchParameteri;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glPatchParameterfv(int pname, float* values);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_tessellation_shader", Api = "gl|glcore")] [ThreadStatic]
            internal static glPatchParameterfv pglPatchParameterfv;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glBindTransformFeedback(int target, uint id);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")] [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")] [ThreadStatic]
            internal static glBindTransformFeedback pglBindTransformFeedback;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glDeleteTransformFeedbacks(int n, uint* ids);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2", EntryPoint = "glDeleteTransformFeedbacksNV")]
            [ThreadStatic]
            internal static glDeleteTransformFeedbacks pglDeleteTransformFeedbacks;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGenTransformFeedbacks(int n, uint* ids);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2", EntryPoint = "glGenTransformFeedbacksNV")]
            [ThreadStatic]
            internal static glGenTransformFeedbacks pglGenTransformFeedbacks;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2")]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.I1)]
            internal delegate bool glIsTransformFeedback(uint id);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2", EntryPoint = "glIsTransformFeedbackNV")]
            [ThreadStatic]
            internal static glIsTransformFeedback pglIsTransformFeedback;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glPauseTransformFeedback();

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2", EntryPoint = "glPauseTransformFeedbackNV")]
            [ThreadStatic]
            internal static glPauseTransformFeedback pglPauseTransformFeedback;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glResumeTransformFeedback();

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ES_VERSION_3_0", Api = "gles2")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_NV_transform_feedback2", EntryPoint = "glResumeTransformFeedbackNV")]
            [ThreadStatic]
            internal static glResumeTransformFeedback pglResumeTransformFeedback;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_draw_transform_feedback", Api = "gles2")]
            [RequiredByFeature("GL_NV_transform_feedback2")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glDrawTransformFeedback(int mode, uint id);

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_transform_feedback2", Api = "gl|glcore")]
            [RequiredByFeature("GL_EXT_draw_transform_feedback", Api = "gles2", EntryPoint = "glDrawTransformFeedbackEXT")]
            [RequiredByFeature("GL_NV_transform_feedback2", EntryPoint = "glDrawTransformFeedbackNV")]
            [ThreadStatic]
            internal static glDrawTransformFeedback pglDrawTransformFeedback;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glDrawTransformFeedbackStream(int mode, uint id, uint stream);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")] [ThreadStatic]
            internal static glDrawTransformFeedbackStream pglDrawTransformFeedbackStream;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glBeginQueryIndexed(int target, uint index, uint id);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")] [ThreadStatic]
            internal static glBeginQueryIndexed pglBeginQueryIndexed;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glEndQueryIndexed(int target, uint index);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")] [ThreadStatic]
            internal static glEndQueryIndexed pglEndQueryIndexed;

            [RequiredByFeature("GL_VERSION_4_0")]
            [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetQueryIndexediv(int target, uint index, int pname, int* @params);

            [RequiredByFeature("GL_VERSION_4_0")] [RequiredByFeature("GL_ARB_transform_feedback3", Api = "gl|glcore")] [ThreadStatic]
            internal static glGetQueryIndexediv pglGetQueryIndexediv;
        }
    }
}