﻿// --------------------------------
// Platform Code
// --------------------------------

function GameLoop(timeStamp) {
    Emotion.manager.invokeMethod("RunLoop", timeStamp);
    window.requestAnimationFrame(GameLoop);
}

function onResize() {
    if (!Emotion.canvas) return;

    Emotion.canvas.width = window.innerWidth;
    Emotion.canvas.height = window.innerHeight;
    Emotion.manager.invokeMethodAsync("HostResized", Emotion.canvas.width, Emotion.canvas.height);
}

function GetHostSize() {
    return [Emotion.canvas.width, Emotion.canvas.height];
}

window.InitJavascript = (manager) => {
    var canvasContainer = document.getElementById("container");
    var canvases = canvasContainer.getElementsByTagName("canvas") || [];
    var canvas = canvases.length ? canvases[0] : null;
    var context;
    if (canvas) {
        context = canvas.getContext("webgl2");
    }

    window.Emotion = {
        manager: manager,
        canvas: canvas,
        gl: context || false
    };

    window.addEventListener("resize", onResize);
    onResize();
    window.requestAnimationFrame(GameLoop);
};

// --------------------------------
// WebGL Driver
// --------------------------------

const SIZEOF_FLOAT = 4;
const SIZEOF_INT = 4;

function glGetError() {
    //return Emotion.gl.getError();
    return 0;
}

function glGet(id) {
    var value = Emotion.gl.getParameter(id);
    if (value === undefined) {
        value = 0;
    }
    if (typeof(value) === "string") {
        return BINDING.js_to_mono_obj(value);
    }
    // ElementBuffer and ArrayBuffer Binding respectively. These return WebGL buffers rather than the index :(
    if (id === 0x8895 || id === 0x8894)
    {
        for (let i = 0; i < gBuffers.length; i++) {
            if (gBuffers[i] === value) {
                value = i + 1;
                break;
            }
        }
    }
    if (typeof(value) === "number") {
        value = [value];
    }
    value = new Int32Array(value);
    return BINDING.js_typed_array_to_array(value);
}

function GetGLExtensions() {
    return BINDING.js_to_mono_obj(Emotion.gl.getSupportedExtensions().join(" "));
}

gBuffers = [];
gBuffers[-1] = null;

function glGenBuffers(count) {
    const buffers = new Uint32Array(count);
    for (let i = 0; i < count; i++) {
        const newBuffer = Emotion.gl.createBuffer();
        gBuffers.push(newBuffer);
        buffers[i] = gBuffers.length;
    }
    return BINDING.js_typed_array_to_array(buffers);
}

function glBindBuffer(target, bufferId) {
    const buffer = bufferId < 0 ? null : gBuffers[bufferId - 1];
    Emotion.gl.bindBuffer(target, buffer);
}

function glBufferData(argsPtr) {
    // struct BufferDataArgs
    const target = Blazor.platform.readInt32Field(argsPtr, 0);
    const size = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT);
    const memoryPtr = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT * 2);
    const usage = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT * 3);
    const offset = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT * 4);
    const length = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT * 5);

    const memory = new Uint8Array(wasmMemory.buffer, memoryPtr, size);
    Emotion.gl.bufferData(target, memory, usage, offset, length);
}

function glBufferSubData(argsPtr) {
    // struct BufferDataArgs
    const target = Blazor.platform.readInt32Field(argsPtr, 0);
    const size = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT);
    const memoryPtr = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT * 2);
    const usage = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT * 3);
    const offset = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT * 4);
    const length = Blazor.platform.readInt32Field(argsPtr, SIZEOF_INT * 5);

    const memory = new Uint8Array(wasmMemory.buffer, memoryPtr, length);
    Emotion.gl.bufferSubData(target, offset, memory, 0, length);
}

function glClear(mask) {
    Emotion.gl.clear(mask);
}

function glClearColor(vec4Col) {
    // struct Vector4
    const r = Blazor.platform.readFloatField(vec4Col, 0);
    const g = Blazor.platform.readFloatField(vec4Col, SIZEOF_FLOAT);
    const b = Blazor.platform.readFloatField(vec4Col, SIZEOF_FLOAT * 2);
    const a = Blazor.platform.readFloatField(vec4Col, SIZEOF_FLOAT * 3);
    Emotion.gl.clearColor(r, g, b, a);
}

function glEnable(feature) {
    Emotion.gl.enable(feature);
}

function glDepthFunc(id) {
    Emotion.gl.depthFunc(id);
}

function glDisable(feature) {
    Emotion.gl.disable(feature);
}

function glStencilMask(maskType) {
    Emotion.gl.stencilMask(maskType);
}

function glStencilFunc(func, rev, mask) {
    Emotion.gl.stencilFunc(func, rev, mask);
}

function glStencilOp(fail, zfail, pass) {
    Emotion.gl.stencilOp(fail, zfail, pass);
}

function glBlendFuncSeparate(valuePtr) {
    // struct IntegerVector4
    const srcRgb = Blazor.platform.readInt32Field(valuePtr, 0);
    const dstRgb = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT);
    const srcAlpha = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 2);
    const dstAlpha = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 3);
    Emotion.gl.blendFuncSeparate(srcRgb, dstRgb, srcAlpha, dstAlpha);
}

function glViewport(valuePtr) {
    // struct IntegerVector4
    const x = Blazor.platform.readInt32Field(valuePtr, 0);
    const y = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT);
    const w = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 2);
    const h = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 3);
    Emotion.gl.viewport(x, y, w, h);
}

gShaders = [];
gShaders[-1] = null;

function glCreateShader(type) {
    const shader = Emotion.gl.createShader(type);
    gShaders.push(shader);
    return gShaders.length;
}

function glShaderSource(shaderId, source) {
    const shader = gShaders[shaderId - 1];
    const shaderSourceJs = BINDING.conv_string(source);
    Emotion.gl.shaderSource(shader, shaderSourceJs);
}

function glCompileShader(shaderId) {
    const shader = gShaders[shaderId - 1];
    Emotion.gl.compileShader(shader, shader);
}

function glGetShaderParam(shaderId, param) {
    const shader = gShaders[shaderId - 1];
    var value = Emotion.gl.getShaderParameter(shader, param);
    if (value === null) return null;
    if (typeof(value) === "number")
        value = [value];
    else if (typeof(value) === "boolean")
        value = [value ? 1 : 0];

    value = new Int32Array(value);
    return BINDING.js_typed_array_to_array(value);
}

function glGetShaderInfo(shaderId) {
    const shader = gShaders[shaderId - 1];
    const value = Emotion.gl.getShaderInfoLog(shader);
    return BINDING.js_to_mono_obj(value);
}

gPrograms = [];
gPrograms[-1] = null;

function glCreateProgram() {
    const program = Emotion.gl.createProgram();
    gPrograms.push(program);
    return gPrograms.length;
}

function glUseProgram(programId) {
    const program = gPrograms[programId - 1];
    Emotion.gl.useProgram(program);
}

function glAttachShader(programId, shaderId) {
    const program = gPrograms[programId - 1];
    const shader = gShaders[shaderId - 1];
    Emotion.gl.attachShader(program, shader);
}

function glBindAttribLocation(programId, index, name) {
    const program = gPrograms[programId - 1];
    const nameJs = BINDING.conv_string(name);
    Emotion.gl.bindAttribLocation(program, index, nameJs);
}

function glLinkProgram(programId) {
    const program = gPrograms[programId - 1];
    Emotion.gl.linkProgram(program);
}

function glGetProgramInfo(programId) {
    const program = gPrograms[programId - 1];
    const value = Emotion.gl.getProgramInfoLog(program);
    return BINDING.js_to_mono_obj(value);
}

function glGetProgramParam(programId, param) {
    const program = gPrograms[programId - 1];
    var value = Emotion.gl.getProgramParameter(program, param);
    if (value === null) return null;
    if (typeof(value) === "number")
        value = [value];
    else if (typeof(value) === "boolean")
        value = [value ? 1 : 0];

    value = new Int32Array(value);
    return BINDING.js_typed_array_to_array(value);
}

gShaderUniformLocations = [];
gShaderUniformLocations[-1] = null;
gShaderUniformLocationToString = []; // For debugging purposes

function glGetUniformLoc(programId, name) {
    const programIdx = programId - 1;
    const program = gPrograms[programIdx];
    const nameJs = BINDING.conv_string(name);

    const location = Emotion.gl.getUniformLocation(program, nameJs);
    if (location === null) return -1;

    // Before adding it to the lookup table, make sure it isn't there already.
    // This could be optimized with a second table.
    for (let i = 0; i < gShaderUniformLocations.length; i++) {
        if (gShaderUniformLocations[i] === location) {
            return i;
        }
    }

    gShaderUniformLocations.push(location);
    gShaderUniformLocationToString.push(`[${programIdx}] ${nameJs}`);
    return gShaderUniformLocations.length;
}

function glUniformIntArray(locationId, count, valuePtr) {
    const location = gShaderUniformLocations[locationId - 1];
    const data = new Int32Array(wasmMemory.buffer, valuePtr, count);
    Emotion.gl.uniform1iv(location, data);
}

function glUniformFloat(locationId, valuePtr) {
    const location = gShaderUniformLocations[locationId - 1];
    // struct BoxedFloat
    const value = Blazor.platform.readFloatField(valuePtr, 0);
    Emotion.gl.uniform1f(location, value);
}

function glUniformFloat2(locationId, valuePtr) {
    const location = gShaderUniformLocations[locationId - 1];
    // struct Vector2
    const value = Blazor.platform.readFloatField(valuePtr, 0);
    const value2 = Blazor.platform.readFloatField(valuePtr, SIZEOF_FLOAT);
    Emotion.gl.uniform2f(location, value, value2);
}

function glUniformFloat3(locationId, valuePtr) {
    const location = gShaderUniformLocations[locationId - 1];
    // struct Vector3
    const value = Blazor.platform.readFloatField(valuePtr, 0);
    const value2 = Blazor.platform.readFloatField(valuePtr, SIZEOF_FLOAT);
    const value3 = Blazor.platform.readFloatField(valuePtr, SIZEOF_FLOAT * 2);
    Emotion.gl.uniform3f(location, value, value2, value3);
}

function glUniformFloat4(locationId, valuePtr) {
    const location = gShaderUniformLocations[locationId - 1];
    // struct Vector4
    const value = Blazor.platform.readFloatField(valuePtr, 0);
    const value2 = Blazor.platform.readFloatField(valuePtr, SIZEOF_FLOAT);
    const value3 = Blazor.platform.readFloatField(valuePtr, SIZEOF_FLOAT * 2);
    const value4 = Blazor.platform.readFloatField(valuePtr, SIZEOF_FLOAT * 3);
    Emotion.gl.uniform4f(location, value, value2, value3, value4);
}

function glUniformFloatArray(locationId, count, valuePtr) {
    const location = gShaderUniformLocations[locationId - 1];
    const data = new Float32Array(wasmMemory.buffer, valuePtr, count);
    Emotion.gl.uniform1fv(location, data);
}

function glUniformMultiFloatArray(locationId, valuePtr) {
    const location = gShaderUniformLocations[locationId - 1];
    // struct MatrixUniformUploadData
    const componentCount = Blazor.platform.readInt32Field(valuePtr, 0);
    const arrayLength = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT);
    const dataPtr = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 2);

    const data = new Float32Array(wasmMemory.buffer, dataPtr, componentCount * arrayLength);
    if (componentCount === 2) {
        Emotion.gl.uniform2fv(location, data);
    } else if (componentCount === 3) {
        Emotion.gl.uniform3fv(location, data);
    } else if (componentCount === 4) {
        Emotion.gl.uniform4fv(location, data);
    }
}

function glUniformMatrix(locationId, valuePtr) {
    const location = gShaderUniformLocations[locationId - 1];
    // struct MatrixUniformUploadData
    const componentCount = Blazor.platform.readInt32Field(valuePtr, 0);
    const arrayLength = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT);
    const dataPtr = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 2);
    const transpose = getValue(valuePtr + SIZEOF_INT * 3, "i1") === 1;

    const dataLength = componentCount * componentCount * arrayLength;
    const data = new Float32Array(wasmMemory.buffer, dataPtr, dataLength);
    Emotion.gl.uniformMatrix4fv(location, transpose, data);
}

gFramebuffers = [];
gFramebuffers[-1] = null;

function glBindFramebuffer(target, bufferId) {
    const frameBuffer = gFramebuffers[bufferId - 1];
    Emotion.gl.bindFramebuffer(target, frameBuffer);
}

gVertexArrays = [];
gVertexArrays[-1] = null;

function glGenVertexArrays(count) {
    const buffers = new Uint32Array(count);
    for (let i = 0; i < count; i++) {
        const newBuffer = Emotion.gl.createVertexArray();
        gVertexArrays.push(newBuffer);
        buffers[i] = gVertexArrays.length;
    }
    return BINDING.js_typed_array_to_array(buffers);
}

function glBindVertexArray(bufferId) {
    const buffer = gVertexArrays[bufferId - 1];
    Emotion.gl.bindVertexArray(buffer);
}

function glEnableVertexAttribArray(attribId) {
    Emotion.gl.enableVertexAttribArray(attribId);
}

function glVertexAttribPointer(valuePtr) {
    // struct VertexAttribData
    const index = Blazor.platform.readInt32Field(valuePtr, 0);
    const size = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT);
    const type = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 2);
    const normalized = getValue(valuePtr + SIZEOF_INT * 3, "i1") === 1;
    const stride = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 4 + 1);
    const offset = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 5 + 1);
    Emotion.gl.vertexAttribPointer(index, size, type, normalized, stride, offset);
}

function glDrawElements(valuePtr) {
    // struct IntegerVector4
    const mode = Blazor.platform.readInt32Field(valuePtr, 0);
    const count = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT);
    const type = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 2);
    const offset = Blazor.platform.readInt32Field(valuePtr, SIZEOF_INT * 3);
    Emotion.gl.drawElements(mode, count, type, offset);
}