﻿#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using Emotion.Graphics;
using Emotion.Plugins.ImGuiNet.Windowing;
using Emotion.Tools.Windows.Art;
using ImGuiNET;

#endregion

namespace Emotion.Tools.Windows
{
    public static class ToolsMenu
    {
        public static Dictionary<string, Action<WindowManager>> CustomTools = new Dictionary<string, Action<WindowManager>>();

        public static void RenderToolsMenu(this RenderComposer composer, WindowManager manager)
        {
            ImGui.BeginMainMenuBar();

            if (ImGui.BeginMenu("Audio"))
            {
                if (ImGui.MenuItem("Old Editor")) manager.AddWindow(new AudioEditor());
                if (ImGui.MenuItem("Audio Mixer")) manager.AddWindow(new AudioMixer());
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Art"))
            {
                if (ImGui.MenuItem("Animation Editor")) manager.AddWindow(new AnimationEditor());
                if (ImGui.MenuItem("Rogue Alpha Remover")) manager.AddWindow(new RogueAlphaRemoval());
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Gameplay"))
            {
                if (ImGui.MenuItem("Map Editor")) manager.AddWindow(new MapEditor());
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Engine"))
            {
                if (ImGui.MenuItem("Performance Monitor")) manager.AddWindow(new PerformanceMonitor());
                ImGui.EndMenu();
            }

            if (ImGui.BeginMenu("Game"))
            {
                foreach (KeyValuePair<string, Action<WindowManager>> tool in CustomTools.Where(tool => ImGui.MenuItem(tool.Key)))
                {
                    tool.Value(manager);
                }

                ImGui.EndMenu();
            }

            ImGui.EndMainMenuBar();
        }
    }
}