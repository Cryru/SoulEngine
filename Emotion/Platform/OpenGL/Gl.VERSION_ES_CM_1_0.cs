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
        /// [GL] Value of GL_VERSION_ES_CL_1_0 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public const int VERSION_ES_CL_1_0 = 1;

        /// <summary>
        /// [GL] Value of GL_VERSION_ES_CM_1_1 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public const int VERSION_ES_CM_1_1 = 1;

        /// <summary>
        /// [GL] Value of GL_VERSION_ES_CL_1_1 symbol.
        /// </summary>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public const int VERSION_ES_CL_1_1 = 1;

        /// <summary>
        /// [GLES1.1] glClipPlanef: specify a plane against which all geometry is clipped
        /// </summary>
        /// <param name="p">
        /// A <see cref="T:ClipPlaneName" />.
        /// </param>
        /// <param name="eqn">
        /// A <see cref="T:float[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
        public static void ClipPlane(ClipPlaneName p, float[] eqn)
        {
            Debug.Assert(eqn.Length >= 4);
            unsafe
            {
                fixed (float* p_eqn = eqn)
                {
                    Debug.Assert(Delegates.pglClipPlanef != null, "pglClipPlanef not implemented");
                    Delegates.pglClipPlanef((int) p, p_eqn);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glFrustumf: multiply the current matrix by a perspective matrix
        /// </summary>
        /// <param name="left">
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="right">
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="bottom">
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="top">
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="near">
        /// Specify the distances to the near and far depth clipping planes. Both distances must be positive.
        /// </param>
        /// <param name="far">
        /// Specify the distances to the near and far depth clipping planes. Both distances must be positive.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
        public static void Frustum(float left, float right, float bottom, float top, float near, float far)
        {
            Debug.Assert(Delegates.pglFrustumf != null, "pglFrustumf not implemented");
            Delegates.pglFrustumf(left, right, bottom, top, near, far);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glGetClipPlanef: return the coefficients of the specified clipping plane
        /// </summary>
        /// <param name="plane">
        /// Specifies a clipping plane. The number of clipping planes depends on the implementation, but at least six clipping
        /// planes are supported. Symbolic names of the form Gl.CLIP_PLANEi, where i is an integer between 0 and
        /// Gl.MAX_CLIP_PLANES-1, are accepted.
        /// </param>
        /// <param name="equation">
        /// Returns four fixed-point or floating-point values that are the coefficients of the plane equation of
        /// <paramref
        ///     name="plane" />
        /// in eye coordinates in the order p1, p2, p3, and p4. The initial value is (0, 0, 0, 0).
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
        public static void GetClipPlane(ClipPlaneName plane, [Out] float[] equation)
        {
            Debug.Assert(equation.Length >= 4);
            unsafe
            {
                fixed (float* p_equation = equation)
                {
                    Debug.Assert(Delegates.pglGetClipPlanef != null, "pglGetClipPlanef not implemented");
                    Delegates.pglGetClipPlanef((int) plane, p_equation);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glOrthof: multiply the current matrix with an orthographic matrix
        /// </summary>
        /// <param name="left">
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="right">
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="bottom">
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="top">
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="near">
        /// Specify the distances to the nearer and farther depth clipping planes. These values are negative if the plane is to be
        /// behind the viewer.
        /// </param>
        /// <param name="far">
        /// Specify the distances to the nearer and farther depth clipping planes. These values are negative if the plane is to be
        /// behind the viewer.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
        public static void Ortho(float left, float right, float bottom, float top, float near, float far)
        {
            Debug.Assert(Delegates.pglOrthof != null, "pglOrthof not implemented");
            Delegates.pglOrthof(left, right, bottom, top, near, far);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glAlphaFuncx: specify the alpha test function
        /// </summary>
        /// <param name="func">
        /// Specifies the alpha comparison function. Symbolic constants Gl.NEVER, Gl.LESS, Gl.EQUAL, Gl.LEQUAL, Gl.GREATER,
        /// Gl.NOTEQUAL, Gl.GEQUAL, and Gl.ALWAYS are accepted. The initial value is Gl.ALWAYS.
        /// </param>
        /// <param name="ref">
        /// Specifies the reference value that incoming alpha values are compared to. This value is clamped to the range [0, 1],
        /// where 0 represents the lowest possible alpha value and 1 the highest possible value. The initial reference value is 0.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void AlphaFunc(AlphaFunction func, IntPtr @ref)
        {
            Debug.Assert(Delegates.pglAlphaFuncx != null, "pglAlphaFuncx not implemented");
            Delegates.pglAlphaFuncx((int) func, @ref);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glClearColorx: specify clear values for the color buffer
        /// </summary>
        /// <param name="red">
        /// Specify the red, green, blue, and alpha values used when the color buffer is cleared. The initial values are all 0.
        /// </param>
        /// <param name="green">
        /// Specify the red, green, blue, and alpha values used when the color buffer is cleared. The initial values are all 0.
        /// </param>
        /// <param name="blue">
        /// Specify the red, green, blue, and alpha values used when the color buffer is cleared. The initial values are all 0.
        /// </param>
        /// <param name="alpha">
        /// Specify the red, green, blue, and alpha values used when the color buffer is cleared. The initial values are all 0.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void ClearColor(IntPtr red, IntPtr green, IntPtr blue, IntPtr alpha)
        {
            Debug.Assert(Delegates.pglClearColorx != null, "pglClearColorx not implemented");
            Delegates.pglClearColorx(red, green, blue, alpha);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glClearDepthx: specify the clear value for the depth buffer
        /// </summary>
        /// <param name="depth">
        /// Specifies the depth value used when the depth buffer is cleared. The initial value is 1.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void ClearDepth(IntPtr depth)
        {
            Debug.Assert(Delegates.pglClearDepthx != null, "pglClearDepthx not implemented");
            Delegates.pglClearDepthx(depth);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glClipPlanex: specify a plane against which all geometry is clipped
        /// </summary>
        /// <param name="plane">
        /// Specifies which clipping plane is being positioned. Symbolic names of the form Gl.CLIP_PLANEi, where i is an integer
        /// between 0 and Gl.MAX_CLIP_PLANES-1, are accepted.
        /// </param>
        /// <param name="equation">
        /// Specifies the address of an array of four fixed-point or floating-point values. These are the coefficients of a plane
        /// equation in object coordinates: p1, p2, p3, and p4, in that order.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void ClipPlane(ClipPlaneName plane, IntPtr[] equation)
        {
            Debug.Assert(equation.Length >= 4);
            unsafe
            {
                fixed (IntPtr* p_equation = equation)
                {
                    Debug.Assert(Delegates.pglClipPlanex != null, "pglClipPlanex not implemented");
                    Delegates.pglClipPlanex((int) plane, p_equation);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glColor4x: set the current color
        /// </summary>
        /// <param name="red">
        /// Specify new red, green, blue, and alpha values for the current color.
        /// </param>
        /// <param name="green">
        /// Specify new red, green, blue, and alpha values for the current color.
        /// </param>
        /// <param name="blue">
        /// Specify new red, green, blue, and alpha values for the current color.
        /// </param>
        /// <param name="alpha">
        /// Specify new red, green, blue, and alpha values for the current color.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Color4(IntPtr red, IntPtr green, IntPtr blue, IntPtr alpha)
        {
            Debug.Assert(Delegates.pglColor4x != null, "pglColor4x not implemented");
            Delegates.pglColor4x(red, green, blue, alpha);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glDepthRangex: specify mapping of depth values from normalized device coordinates to window coordinates
        /// </summary>
        /// <param name="n">
        /// A <see cref="T:IntPtr" />.
        /// </param>
        /// <param name="f">
        /// A <see cref="T:IntPtr" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void DepthRange(IntPtr n, IntPtr f)
        {
            Debug.Assert(Delegates.pglDepthRangex != null, "pglDepthRangex not implemented");
            Delegates.pglDepthRangex(n, f);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glFogx: specify fog parameters
        /// </summary>
        /// <param name="pname">
        /// Specifies a single-valued fog parameter. Gl.FOG_MODE, Gl.FOG_DENSITY, Gl.FOG_START, and Gl.FOG_END are accepted.
        /// </param>
        /// <param name="param">
        /// Specifies the value that <paramref name="pname" /> will be set to.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Fog(FogPName pname, IntPtr param)
        {
            Debug.Assert(Delegates.pglFogx != null, "pglFogx not implemented");
            Delegates.pglFogx((int) pname, param);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glFogxv: specify fog parameters
        /// </summary>
        /// <param name="pname">
        /// Specifies a single-valued fog parameter. Gl.FOG_MODE, Gl.FOG_DENSITY, Gl.FOG_START, and Gl.FOG_END are accepted.
        /// </param>
        /// <param name="param">
        /// Specifies the value that <paramref name="pname" /> will be set to.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Fog(FogPName pname, IntPtr[] param)
        {
            unsafe
            {
                fixed (IntPtr* p_param = param)
                {
                    Debug.Assert(Delegates.pglFogxv != null, "pglFogxv not implemented");
                    Delegates.pglFogxv((int) pname, p_param);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glFrustumx: multiply the current matrix by a perspective matrix
        /// </summary>
        /// <param name="left">
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="right">
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="bottom">
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="top">
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="near">
        /// Specify the distances to the near and far depth clipping planes. Both distances must be positive.
        /// </param>
        /// <param name="far">
        /// Specify the distances to the near and far depth clipping planes. Both distances must be positive.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Frustum(IntPtr left, IntPtr right, IntPtr bottom, IntPtr top, IntPtr near, IntPtr far)
        {
            Debug.Assert(Delegates.pglFrustumx != null, "pglFrustumx not implemented");
            Delegates.pglFrustumx(left, right, bottom, top, near, far);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glGetClipPlanex: return the coefficients of the specified clipping plane
        /// </summary>
        /// <param name="plane">
        /// Specifies a clipping plane. The number of clipping planes depends on the implementation, but at least six clipping
        /// planes are supported. Symbolic names of the form Gl.CLIP_PLANEi, where i is an integer between 0 and
        /// Gl.MAX_CLIP_PLANES-1, are accepted.
        /// </param>
        /// <param name="equation">
        /// Returns four fixed-point or floating-point values that are the coefficients of the plane equation of
        /// <paramref
        ///     name="plane" />
        /// in eye coordinates in the order p1, p2, p3, and p4. The initial value is (0, 0, 0, 0).
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void GetClipPlane(ClipPlaneName plane, [Out] IntPtr[] equation)
        {
            Debug.Assert(equation.Length >= 4);
            unsafe
            {
                fixed (IntPtr* p_equation = equation)
                {
                    Debug.Assert(Delegates.pglGetClipPlanex != null, "pglGetClipPlanex not implemented");
                    Delegates.pglGetClipPlanex((int) plane, p_equation);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glGetFixedv: return the value or values of a selected parameter
        /// </summary>
        /// <param name="pname">
        /// Specifies the parameter value to be returned. The symbolic constants in the list below are accepted.
        /// </param>
        /// <param name="params">
        /// Returns the value or values of the specified parameter.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void GetFixed(GetPName pname, [Out] IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetFixedv != null, "pglGetFixedv not implemented");
                    Delegates.pglGetFixedv((int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glGetLightxv: return light source parameter values
        /// </summary>
        /// <param name="light">
        /// Specifies a light source. The number of possible lights depends on the implementation, but at least eight lights are
        /// supported. They are identified by symbolic names of the form GL_LIGHTi where 0&lt;i&lt;GL_MAX_LIGHTS
        /// </param>
        /// <param name="pname">
        /// Specifies a light source parameter for light. Accepted symbolic names are Gl.AMBIENT, Gl.DIFFUSE, Gl.SPECULAR,
        /// Gl.POSITION, Gl.SPOT_DIRECTION, Gl.SPOT_EXPONENT, Gl.SPOT_CUTOFF, Gl.CONSTANT_ATTENUATION, Gl.LINEAR_ATTENUATION, and
        /// Gl.QUADRATIC_ATTENUATION.
        /// </param>
        /// <param name="params">
        /// Returns the requested data.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void GetLightxv(LightName light, LightParameter pname, [Out] IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetLightxv != null, "pglGetLightxv not implemented");
                    Delegates.pglGetLightxv((int) light, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glGetMaterialxv: return material parameters values
        /// </summary>
        /// <param name="face">
        /// Specifies which of the two materials is being queried. Gl.FRONT or Gl.BACK are accepted, representing the front and
        /// back
        /// materials, respectively.
        /// </param>
        /// <param name="pname">
        /// Specifies the material parameter to return. Accepted symbolic names are Gl.AMBIENT, Gl.DIFFUSE, Gl.SPECULAR,
        /// Gl.EMISSION, and Gl.SHININESS.
        /// </param>
        /// <param name="params">
        /// Returns the requested data.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void GetMaterial(MaterialFace face, MaterialParameter pname, [Out] IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetMaterialxv != null, "pglGetMaterialxv not implemented");
                    Delegates.pglGetMaterialxv((int) face, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glGetTexEnvxv: return texture environment parameters
        /// </summary>
        /// <param name="target">
        /// Specifies a texture environment. May be Gl.TEXTURE_ENV or Gl.POINT_SPRITE_OES.
        /// </param>
        /// <param name="pname">
        /// Specifies the symbolic name of a texture environment parameter. Accepted values are Gl.TEXTURE_ENV_MODE,
        /// Gl.TEXTURE_ENV_COLOR, Gl.COMBINE_RGB, Gl.COMBINE_ALPHA, Gl.SRC0_RGB, Gl.SRC1_RGB, Gl.SRC2_RGB, Gl.SRC0_ALPHA,
        /// Gl.SRC1_ALPHA, Gl.SRC2_ALPHA, Gl.OPERAND0_RGB, Gl.OPERAND1_RGB, Gl.OPERAND2_RGB, Gl.OPERAND0_ALPHA, Gl.OPERAND1_ALPHA,
        /// Gl.OPERAND2_ALPHA, Gl.RGB_SCALE, Gl.ALPHA_SCALE, or Gl.COORD_REPLACE_OES.
        /// </param>
        /// <param name="params">
        /// Returns the requested data.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void GetTexEnv(TextureEnvTarget target, TextureEnvParameter pname, [Out] IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetTexEnvxv != null, "pglGetTexEnvxv not implemented");
                    Delegates.pglGetTexEnvxv((int) target, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glGetTexParameterxv: return texture parameter values
        /// </summary>
        /// <param name="target">
        /// Specifies the target texture, which must be Gl.TEXTURE_2D.
        /// </param>
        /// <param name="pname">
        /// Specifies the symbolic name of a texture parameter. Which can be one of the following: Gl.TEXTURE_MIN_FILTER,
        /// Gl.TEXTURE_MAG_FILTER, Gl.TEXTURE_WRAP_S, Gl.TEXTURE_WRAP_T, or Gl.GENERATE_MIPMAP.
        /// </param>
        /// <param name="params">
        /// Returns texture parameters.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void GetTexParameter(TextureTarget target, GetTextureParameter pname, [Out] IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglGetTexParameterxv != null, "pglGetTexParameterxv not implemented");
                    Delegates.pglGetTexParameterxv((int) target, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glLightModelx: set the lighting model parameters
        /// </summary>
        /// <param name="pname">
        /// Specifies a single-valued lighting model parameter. Must be Gl.LIGHT_MODEL_TWO_SIDE.
        /// </param>
        /// <param name="param">
        /// Specifies the value that <paramref name="param" /> will be set to.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void LightModel(LightModelParameter pname, IntPtr param)
        {
            Debug.Assert(Delegates.pglLightModelx != null, "pglLightModelx not implemented");
            Delegates.pglLightModelx((int) pname, param);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glLightModelxv: set the lighting model parameters
        /// </summary>
        /// <param name="pname">
        /// Specifies a single-valued lighting model parameter. Must be Gl.LIGHT_MODEL_TWO_SIDE.
        /// </param>
        /// <param name="param">
        /// Specifies the value that <paramref name="param" /> will be set to.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void LightModel(LightModelParameter pname, IntPtr[] param)
        {
            unsafe
            {
                fixed (IntPtr* p_param = param)
                {
                    Debug.Assert(Delegates.pglLightModelxv != null, "pglLightModelxv not implemented");
                    Delegates.pglLightModelxv((int) pname, p_param);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glLightx: set light source parameters
        /// </summary>
        /// <param name="light">
        /// Specifies a light. The number of lights depends on the implementation, but at least eight lights are supported. They
        /// are
        /// identified by symbolic names of the form Gl.LIGHTi where 0&lt;=i&lt;GL_MAX_LIGHTS.
        /// </param>
        /// <param name="pname">
        /// Specifies a single-valued light source parameter for <paramref name="light" />. Gl.SPOT_EXPONENT, Gl.SPOT_CUTOFF,
        /// Gl.CONSTANT_ATTENUATION, Gl.LINEAR_ATTENUATION, and Gl.QUADRATIC_ATTENUATION are accepted.
        /// </param>
        /// <param name="param">
        /// Specifies the value that parameter <paramref name="pname" /> of light source <paramref name="light" /> will be set to.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Lightx(LightName light, LightParameter pname, IntPtr param)
        {
            Debug.Assert(Delegates.pglLightx != null, "pglLightx not implemented");
            Delegates.pglLightx((int) light, (int) pname, param);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glLightxv: set light source parameters
        /// </summary>
        /// <param name="light">
        /// Specifies a light. The number of lights depends on the implementation, but at least eight lights are supported. They
        /// are
        /// identified by symbolic names of the form Gl.LIGHTi where 0&lt;=i&lt;GL_MAX_LIGHTS.
        /// </param>
        /// <param name="pname">
        /// Specifies a single-valued light source parameter for <paramref name="light" />. Gl.SPOT_EXPONENT, Gl.SPOT_CUTOFF,
        /// Gl.CONSTANT_ATTENUATION, Gl.LINEAR_ATTENUATION, and Gl.QUADRATIC_ATTENUATION are accepted.
        /// </param>
        /// <param name="params">
        /// A <see cref="T:IntPtr[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Lightxv(LightName light, LightParameter pname, IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglLightxv != null, "pglLightxv not implemented");
                    Delegates.pglLightxv((int) light, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glLineWidthx: specify the width of rasterized lines
        /// </summary>
        /// <param name="width">
        /// Specifies the width of rasterized lines. The initial value is 1.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void LineWidth(IntPtr width)
        {
            Debug.Assert(Delegates.pglLineWidthx != null, "pglLineWidthx not implemented");
            Delegates.pglLineWidthx(width);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glLoadMatrixx: replace the current matrix with the specified matrix
        /// </summary>
        /// <param name="m">
        /// Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void LoadMatrixx(IntPtr[] m)
        {
            Debug.Assert(m.Length >= 16);
            unsafe
            {
                fixed (IntPtr* p_m = m)
                {
                    Debug.Assert(Delegates.pglLoadMatrixx != null, "pglLoadMatrixx not implemented");
                    Delegates.pglLoadMatrixx(p_m);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glLoadMatrixx: replace the current matrix with the specified matrix
        /// </summary>
        /// <param name="m">
        /// Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static unsafe void LoadMatrixx(IntPtr* m)
        {
            Debug.Assert(Delegates.pglLoadMatrixx != null, "pglLoadMatrixx not implemented");
            Delegates.pglLoadMatrixx(m);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glLoadMatrixx: replace the current matrix with the specified matrix
        /// </summary>
        /// <param name="m">
        /// Specifies a pointer to 16 consecutive values, which are used as the elements of a 4x4 column-major matrix.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void LoadMatrixx<T>(T m) where T : struct
        {
            Debug.Assert(Delegates.pglLoadMatrixx != null, "pglLoadMatrixx not implemented");
            unsafe
            {
                TypedReference refM = __makeref(m);
                IntPtr refMPtr = *(IntPtr*) (&refM);

                Delegates.pglLoadMatrixx((IntPtr*) refMPtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glMaterialx: specify material parameters for the lighting model
        /// </summary>
        /// <param name="face">
        /// Specifies which face or faces are being updated. Must be Gl.FRONT_AND_BACK.
        /// </param>
        /// <param name="pname">
        /// Specifies the single-valued material parameter of the face or faces that is being updated. Must be Gl.SHININESS.
        /// </param>
        /// <param name="param">
        /// Specifies the value that parameter Gl.SHININESS will be set to.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Material(MaterialFace face, MaterialParameter pname, IntPtr param)
        {
            Debug.Assert(Delegates.pglMaterialx != null, "pglMaterialx not implemented");
            Delegates.pglMaterialx((int) face, (int) pname, param);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glMaterialxv: specify material parameters for the lighting model
        /// </summary>
        /// <param name="face">
        /// Specifies which face or faces are being updated. Must be Gl.FRONT_AND_BACK.
        /// </param>
        /// <param name="pname">
        /// Specifies the single-valued material parameter of the face or faces that is being updated. Must be Gl.SHININESS.
        /// </param>
        /// <param name="param">
        /// Specifies the value that parameter Gl.SHININESS will be set to.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Material(MaterialFace face, MaterialParameter pname, IntPtr[] param)
        {
            unsafe
            {
                fixed (IntPtr* p_param = param)
                {
                    Debug.Assert(Delegates.pglMaterialxv != null, "pglMaterialxv not implemented");
                    Delegates.pglMaterialxv((int) face, (int) pname, p_param);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glMultMatrixx: multiply the current matrix with the specified matrix
        /// </summary>
        /// <param name="m">
        /// Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void MultMatrixx(IntPtr[] m)
        {
            Debug.Assert(m.Length >= 16);
            unsafe
            {
                fixed (IntPtr* p_m = m)
                {
                    Debug.Assert(Delegates.pglMultMatrixx != null, "pglMultMatrixx not implemented");
                    Delegates.pglMultMatrixx(p_m);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glMultMatrixx: multiply the current matrix with the specified matrix
        /// </summary>
        /// <param name="m">
        /// Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static unsafe void MultMatrixx(IntPtr* m)
        {
            Debug.Assert(Delegates.pglMultMatrixx != null, "pglMultMatrixx not implemented");
            Delegates.pglMultMatrixx(m);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glMultMatrixx: multiply the current matrix with the specified matrix
        /// </summary>
        /// <param name="m">
        /// Points to 16 consecutive values that are used as the elements of a 4x4 column-major matrix.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void MultMatrixx<T>(T m) where T : struct
        {
            Debug.Assert(Delegates.pglMultMatrixx != null, "pglMultMatrixx not implemented");
            unsafe
            {
                TypedReference refM = __makeref(m);
                IntPtr refMPtr = *(IntPtr*) (&refM);

                Delegates.pglMultMatrixx((IntPtr*) refMPtr.ToPointer());
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glMultiTexCoord4x: set the current texture coordinates
        /// </summary>
        /// <param name="texture">
        /// A <see cref="T:TextureUnit" />.
        /// </param>
        /// <param name="s">
        /// Specify <paramref name="s" />, <paramref name="t" />, <paramref name="r" />, and <paramref name="q" /> texture
        /// coordinates
        /// for <paramref name="target" /> texture unit.
        /// </param>
        /// <param name="t">
        /// Specify <paramref name="s" />, <paramref name="t" />, <paramref name="r" />, and <paramref name="q" /> texture
        /// coordinates
        /// for <paramref name="target" /> texture unit.
        /// </param>
        /// <param name="r">
        /// Specify <paramref name="s" />, <paramref name="t" />, <paramref name="r" />, and <paramref name="q" /> texture
        /// coordinates
        /// for <paramref name="target" /> texture unit.
        /// </param>
        /// <param name="q">
        /// Specify <paramref name="s" />, <paramref name="t" />, <paramref name="r" />, and <paramref name="q" /> texture
        /// coordinates
        /// for <paramref name="target" /> texture unit.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void MultiTexCoord4(TextureUnit texture, IntPtr s, IntPtr t, IntPtr r, IntPtr q)
        {
            Debug.Assert(Delegates.pglMultiTexCoord4x != null, "pglMultiTexCoord4x not implemented");
            Delegates.pglMultiTexCoord4x((int) texture, s, t, r, q);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glNormal3x: set the current normal vector
        /// </summary>
        /// <param name="nx">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of the new current
        /// normal.
        /// The initial value is (0, 0, 1).
        /// </param>
        /// <param name="ny">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of the new current
        /// normal.
        /// The initial value is (0, 0, 1).
        /// </param>
        /// <param name="nz">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of the new current
        /// normal.
        /// The initial value is (0, 0, 1).
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Normal3(IntPtr nx, IntPtr ny, IntPtr nz)
        {
            Debug.Assert(Delegates.pglNormal3x != null, "pglNormal3x not implemented");
            Delegates.pglNormal3x(nx, ny, nz);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glOrthox: multiply the current matrix with an orthographic matrix
        /// </summary>
        /// <param name="left">
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="right">
        /// Specify the coordinates for the left and right vertical clipping planes.
        /// </param>
        /// <param name="bottom">
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="top">
        /// Specify the coordinates for the bottom and top horizontal clipping planes.
        /// </param>
        /// <param name="near">
        /// Specify the distances to the nearer and farther depth clipping planes. These values are negative if the plane is to be
        /// behind the viewer.
        /// </param>
        /// <param name="far">
        /// Specify the distances to the nearer and farther depth clipping planes. These values are negative if the plane is to be
        /// behind the viewer.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Orthox(IntPtr left, IntPtr right, IntPtr bottom, IntPtr top, IntPtr near, IntPtr far)
        {
            Debug.Assert(Delegates.pglOrthox != null, "pglOrthox not implemented");
            Delegates.pglOrthox(left, right, bottom, top, near, far);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glPointParameterx: specify parameters for point rasterization
        /// </summary>
        /// <param name="pname">
        /// Specifies the single-valued parameter to be updated. Can be either Gl.POINT_SIZE_MIN, Gl.POINT_SIZE_MAX, or
        /// Gl.POINT_FADE_THRESHOLD_SIZE.
        /// </param>
        /// <param name="param">
        /// Specifies the value that the parameter will be set to.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void PointParameter(int pname, IntPtr param)
        {
            Debug.Assert(Delegates.pglPointParameterx != null, "pglPointParameterx not implemented");
            Delegates.pglPointParameterx(pname, param);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glPointParameterxv: specify parameters for point rasterization
        /// </summary>
        /// <param name="pname">
        /// Specifies the single-valued parameter to be updated. Can be either Gl.POINT_SIZE_MIN, Gl.POINT_SIZE_MAX, or
        /// Gl.POINT_FADE_THRESHOLD_SIZE.
        /// </param>
        /// <param name="params">
        /// A <see cref="T:IntPtr[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void PointParameter(int pname, IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglPointParameterxv != null, "pglPointParameterxv not implemented");
                    Delegates.pglPointParameterxv(pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glPointSizex: specify the diameter of rasterized points
        /// </summary>
        /// <param name="size">
        /// Specifies the diameter of rasterized points. The initial value is 1.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void PointSize(IntPtr size)
        {
            Debug.Assert(Delegates.pglPointSizex != null, "pglPointSizex not implemented");
            Delegates.pglPointSizex(size);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glPolygonOffsetx: set the scale and units used to calculate depth values
        /// </summary>
        /// <param name="factor">
        /// Specifies a scale factor that is used to create a variable depth offset for each polygon. The initial value is 0.
        /// </param>
        /// <param name="units">
        /// Is multiplied by an implementation-specific value to create a constant depth offset. The initial value is 0.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void PolygonOffset(IntPtr factor, IntPtr units)
        {
            Debug.Assert(Delegates.pglPolygonOffsetx != null, "pglPolygonOffsetx not implemented");
            Delegates.pglPolygonOffsetx(factor, units);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glRotatex: multiply the current matrix by a rotation matrix
        /// </summary>
        /// <param name="angle">
        /// Specifies the angle of rotation, in degrees.
        /// </param>
        /// <param name="x">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of a vector,
        /// respectively.
        /// </param>
        /// <param name="y">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of a vector,
        /// respectively.
        /// </param>
        /// <param name="z">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of a vector,
        /// respectively.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Rotate(IntPtr angle, IntPtr x, IntPtr y, IntPtr z)
        {
            Debug.Assert(Delegates.pglRotatex != null, "pglRotatex not implemented");
            Delegates.pglRotatex(angle, x, y, z);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glSampleCoveragex: specify mask to modify multisampled pixel fragments
        /// </summary>
        /// <param name="value">
        /// Specifies the coverage of the modification mask. The value is clamped to the range [0, 1], where 0 represents no
        /// coverage and 1 full coverage. The initial value is 1.
        /// </param>
        /// <param name="invert">
        /// Specifies whether the modification mask implied by <paramref name="value" /> is inverted or not. The initial value is
        /// Gl.FALSE.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void SampleCoverage(int value, bool invert)
        {
            Debug.Assert(Delegates.pglSampleCoveragex != null, "pglSampleCoveragex not implemented");
            Delegates.pglSampleCoveragex(value, invert);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glScalex: multiply the current matrix by a general scaling matrix
        /// </summary>
        /// <param name="x">
        /// Specify scale factors along the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> axes,
        /// respectively.
        /// </param>
        /// <param name="y">
        /// Specify scale factors along the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> axes,
        /// respectively.
        /// </param>
        /// <param name="z">
        /// Specify scale factors along the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> axes,
        /// respectively.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Scale(IntPtr x, IntPtr y, IntPtr z)
        {
            Debug.Assert(Delegates.pglScalex != null, "pglScalex not implemented");
            Delegates.pglScalex(x, y, z);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glTexEnvx: set texture environment parameters
        /// </summary>
        /// <param name="target">
        /// Specifies a texture environment. May be Gl.TEXTURE_ENV or Gl.POINT_SPRITE_OES.
        /// </param>
        /// <param name="pname">
        /// Specifies the symbolic name of a single-valued texture environment parameter. May be either Gl.TEXTURE_ENV_MODE,
        /// Gl.COMBINE_RGB, Gl.COMBINE_ALPHA, Gl.SRC0_RGB, Gl.SRC1_RGB, Gl.SRC2_RGB, Gl.SRC0_ALPHA, Gl.SRC1_ALPHA, Gl.SRC2_ALPHA,
        /// Gl.OPERAND0_RGB, Gl.OPERAND1_RGB, Gl.OPERAND2_RGB, Gl.OPERAND0_ALPHA, Gl.OPERAND1_ALPHA, Gl.OPERAND2_ALPHA,
        /// Gl.RGB_SCALE, Gl.ALPHA_SCALE, or Gl.COORD_REPLACE_OES.
        /// </param>
        /// <param name="param">
        /// Specifies a single symbolic constant, one of Gl.ADD, Gl.ADD_SIGNED, Gl.DOT3_RGB, Gl.DOT3_RGBA, Gl.INTERPOLATE,
        /// Gl.MODULATE, Gl.DECAL, Gl.BLEND, Gl.REPLACE, Gl.SUBTRACT, Gl.COMBINE, Gl.TEXTURE, Gl.CONSTANT, Gl.PRIMARY_COLOR,
        /// Gl.PREVIOUS, Gl.SRC_COLOR, Gl.ONE_MINUS_SRC_COLOR, Gl.SRC_ALPHA, Gl.ONE_MINUS_SRC_ALPHA, a single boolean value for the
        /// point sprite texture coordinate replacement, or 1.0, 2.0, or 4.0 when specifying the Gl.RGB_SCALE or Gl.ALPHA_SCALE.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void TexEnv(TextureEnvTarget target, TextureEnvParameter pname, IntPtr param)
        {
            Debug.Assert(Delegates.pglTexEnvx != null, "pglTexEnvx not implemented");
            Delegates.pglTexEnvx((int) target, (int) pname, param);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glTexEnvxv: set texture environment parameters
        /// </summary>
        /// <param name="target">
        /// Specifies a texture environment. May be Gl.TEXTURE_ENV or Gl.POINT_SPRITE_OES.
        /// </param>
        /// <param name="pname">
        /// Specifies the symbolic name of a single-valued texture environment parameter. May be either Gl.TEXTURE_ENV_MODE,
        /// Gl.COMBINE_RGB, Gl.COMBINE_ALPHA, Gl.SRC0_RGB, Gl.SRC1_RGB, Gl.SRC2_RGB, Gl.SRC0_ALPHA, Gl.SRC1_ALPHA, Gl.SRC2_ALPHA,
        /// Gl.OPERAND0_RGB, Gl.OPERAND1_RGB, Gl.OPERAND2_RGB, Gl.OPERAND0_ALPHA, Gl.OPERAND1_ALPHA, Gl.OPERAND2_ALPHA,
        /// Gl.RGB_SCALE, Gl.ALPHA_SCALE, or Gl.COORD_REPLACE_OES.
        /// </param>
        /// <param name="params">
        /// A <see cref="T:IntPtr[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void TexEnv(TextureEnvTarget target, TextureEnvParameter pname, IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglTexEnvxv != null, "pglTexEnvxv not implemented");
                    Delegates.pglTexEnvxv((int) target, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glTexParameterx: set texture parameters
        /// </summary>
        /// <param name="target">
        /// Specifies the target texture, which must be Gl.TEXTURE_2D.
        /// </param>
        /// <param name="pname">
        /// Specifies the symbolic name of a single-valued texture parameter. Which can be one of the following:
        /// Gl.TEXTURE_MIN_FILTER, Gl.TEXTURE_MAG_FILTER, Gl.TEXTURE_WRAP_S, Gl.TEXTURE_WRAP_T, or Gl.GENERATE_MIPMAP.
        /// </param>
        /// <param name="param">
        /// Specifies the value of <paramref name="pname" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void TexParameter(TextureTarget target, GetTextureParameter pname, IntPtr param)
        {
            Debug.Assert(Delegates.pglTexParameterx != null, "pglTexParameterx not implemented");
            Delegates.pglTexParameterx((int) target, (int) pname, param);
            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glTexParameterxv: set texture parameters
        /// </summary>
        /// <param name="target">
        /// Specifies the target texture, which must be Gl.TEXTURE_2D.
        /// </param>
        /// <param name="pname">
        /// Specifies the symbolic name of a single-valued texture parameter. Which can be one of the following:
        /// Gl.TEXTURE_MIN_FILTER, Gl.TEXTURE_MAG_FILTER, Gl.TEXTURE_WRAP_S, Gl.TEXTURE_WRAP_T, or Gl.GENERATE_MIPMAP.
        /// </param>
        /// <param name="params">
        /// A <see cref="T:IntPtr[]" />.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void TexParameter(TextureTarget target, GetTextureParameter pname, IntPtr[] @params)
        {
            unsafe
            {
                fixed (IntPtr* p_params = @params)
                {
                    Debug.Assert(Delegates.pglTexParameterxv != null, "pglTexParameterxv not implemented");
                    Delegates.pglTexParameterxv((int) target, (int) pname, p_params);
                }
            }

            DebugCheckErrors(null);
        }

        /// <summary>
        /// [GLES1.1] glTranslatex: multiply the current matrix by a translation matrix
        /// </summary>
        /// <param name="x">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of a translation
        /// vector.
        /// </param>
        /// <param name="y">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of a translation
        /// vector.
        /// </param>
        /// <param name="z">
        /// Specify the <paramref name="x" />, <paramref name="y" />, and <paramref name="z" /> coordinates of a translation
        /// vector.
        /// </param>
        [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
        public static void Translate(IntPtr x, IntPtr y, IntPtr z)
        {
            Debug.Assert(Delegates.pglTranslatex != null, "pglTranslatex not implemented");
            Delegates.pglTranslatex(x, y, z);
            DebugCheckErrors(null);
        }

        internal static unsafe partial class Delegates
        {
            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glClipPlanef(int p, float* eqn);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")] [ThreadStatic]
            internal static glClipPlanef pglClipPlanef;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glFrustumf(float l, float r, float b, float t, float n, float f);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")] [ThreadStatic]
            internal static glFrustumf pglFrustumf;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetClipPlanef(int plane, float* equation);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")] [ThreadStatic]
            internal static glGetClipPlanef pglGetClipPlanef;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glOrthof(float l, float r, float b, float t, float n, float f);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1", Profile = "common")] [ThreadStatic]
            internal static glOrthof pglOrthof;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glAlphaFuncx(int func, IntPtr @ref);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glAlphaFuncx pglAlphaFuncx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glClearColorx(IntPtr red, IntPtr green, IntPtr blue, IntPtr alpha);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glClearColorx pglClearColorx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glClearDepthx(IntPtr depth);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glClearDepthx pglClearDepthx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glClipPlanex(int plane, IntPtr* equation);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glClipPlanex pglClipPlanex;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glColor4x(IntPtr red, IntPtr green, IntPtr blue, IntPtr alpha);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glColor4x pglColor4x;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glDepthRangex(IntPtr n, IntPtr f);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glDepthRangex pglDepthRangex;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glFogx(int pname, IntPtr param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glFogx pglFogx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glFogxv(int pname, IntPtr* param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glFogxv pglFogxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glFrustumx(IntPtr l, IntPtr r, IntPtr b, IntPtr t, IntPtr n, IntPtr f);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glFrustumx pglFrustumx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetClipPlanex(int plane, IntPtr* equation);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glGetClipPlanex pglGetClipPlanex;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetFixedv(int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glGetFixedv pglGetFixedv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetLightxv(int light, int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glGetLightxv pglGetLightxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetMaterialxv(int face, int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glGetMaterialxv pglGetMaterialxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetTexEnvxv(int target, int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glGetTexEnvxv pglGetTexEnvxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glGetTexParameterxv(int target, int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glGetTexParameterxv pglGetTexParameterxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glLightModelx(int pname, IntPtr param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glLightModelx pglLightModelx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glLightModelxv(int pname, IntPtr* param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glLightModelxv pglLightModelxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glLightx(int light, int pname, IntPtr param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glLightx pglLightx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glLightxv(int light, int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glLightxv pglLightxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glLineWidthx(IntPtr width);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glLineWidthx pglLineWidthx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glLoadMatrixx(IntPtr* m);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glLoadMatrixx pglLoadMatrixx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glMaterialx(int face, int pname, IntPtr param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glMaterialx pglMaterialx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glMaterialxv(int face, int pname, IntPtr* param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glMaterialxv pglMaterialxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glMultMatrixx(IntPtr* m);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glMultMatrixx pglMultMatrixx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glMultiTexCoord4x(int texture, IntPtr s, IntPtr t, IntPtr r, IntPtr q);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glMultiTexCoord4x pglMultiTexCoord4x;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glNormal3x(IntPtr nx, IntPtr ny, IntPtr nz);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glNormal3x pglNormal3x;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glOrthox(IntPtr l, IntPtr r, IntPtr b, IntPtr t, IntPtr n, IntPtr f);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glOrthox pglOrthox;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glPointParameterx(int pname, IntPtr param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glPointParameterx pglPointParameterx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glPointParameterxv(int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glPointParameterxv pglPointParameterxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glPointSizex(IntPtr size);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glPointSizex pglPointSizex;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glPolygonOffsetx(IntPtr factor, IntPtr units);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glPolygonOffsetx pglPolygonOffsetx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glRotatex(IntPtr angle, IntPtr x, IntPtr y, IntPtr z);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glRotatex pglRotatex;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glSampleCoveragex(int value, [MarshalAs(UnmanagedType.I1)] bool invert);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glSampleCoveragex pglSampleCoveragex;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glScalex(IntPtr x, IntPtr y, IntPtr z);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glScalex pglScalex;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glTexEnvx(int target, int pname, IntPtr param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glTexEnvx pglTexEnvx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glTexEnvxv(int target, int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glTexEnvxv pglTexEnvxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glTexParameterx(int target, int pname, IntPtr param);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glTexParameterx pglTexParameterx;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glTexParameterxv(int target, int pname, IntPtr* @params);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glTexParameterxv pglTexParameterxv;

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")]
            [SuppressUnmanagedCodeSecurity]
            internal delegate void glTranslatex(IntPtr x, IntPtr y, IntPtr z);

            [RequiredByFeature("GL_VERSION_ES_CM_1_0", Api = "gles1")] [ThreadStatic]
            internal static glTranslatex pglTranslatex;
        }
    }
}