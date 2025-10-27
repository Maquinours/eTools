using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTools_Ultimate.Models
{
    public static class Constants
    {
        private static string[] _modelFilenameRoot = [
            "obj",
            "ani",
            "ctrl",
            "sfx",
            "item",
            "mvr",
            "region",
            "obj",		// ship
            "path"
            ];

        private static string[] _predefinedUsedModelsFolderFiles = [
                ..Enumerable.Range(0, 100).Select(i => string.Format("Part_maleHair{0:00}.o3d", i)), ..Enumerable.Range(0, 100).Select(i => string.Format("Part_femaleHair{0:00}.o3d", i)),
                ..Enumerable.Range(0, 100).Select(i => string.Format("Part_maleHead{0:00}.o3d", i)), ..Enumerable.Range(0, 100).Select(i => string.Format("Part_femaleHead{0:00}.o3d", i)),
                "Part_maleUpper.o3d", "Part_femaleUpper.o3d",
                "Part_maleLower.o3d", "Part_femaleLower.o3d",
                "Part_maleHand.o3d", "Part_femaleHand.o3d",
                "Part_maleFoot.o3d", "Part_femaleFoot.o3d",
                "arrow.o3d", "etc_arrow.o3d",
                "Mvr_Guidepang.o3d", "Mvr_Guidepang.chr", "Mvr_Guidepang_Appear.ani", "Mvr_Guidepang_Default.ani", "Mvr_Guidepang_Disappear.ani",
                "Mvr_McGuidepang.o3d", "Mvr_McGuidepang.chr", "Mvr_McGuidepang_appear.ani", "Mvr_McGuidepang_default.ani", "Mvr_McGuidepang_Disappear.ani",
                "Mvr_AsGuidepang.o3d", "Mvr_AsGuidepang.chr", "Mvr_AsGuidepang_Appear.ani", "Mvr_AsGuidepang_Default.ani", "Mvr_AsGuidepang_Disappear.ani",
                "Mvr_MgGuidepang.o3d", "Mvr_MgGuidepang.chr", "Mvr_MgGuidepang_Appear.ani", "Mvr_MgGuidepang_Dafault.ani", "Mvr_MgGuidepang_DisAppear.ani",
                "Mvr_AcrGuidepang.o3d", "Mvr_AcrGuidepang.chr", "Mvr_AcrGuidepang_Appear.ani", "Mvr_AcrGuidepang_Default.ani", "Mvr_AcrGuidepang_DisAppear.ani",
                "mvr_Ladolf.o3d", "mvr_Ladolf.chr", "mvr_Ladolf_stand.ani",
                "Shadow.o3d",
                "MaCoPrTr16.o3d", "MapleTree01.o3d", "MaCoPrTr17.o3d", "MapleTree02.o3d"];

        private static string[] _predefinedUsedTexturesFolderFiles = [
            "Env.dds",
            "red.tga",
            "Obj_MiniWall01.dds",
            "Obj_MiniWall02.dds",
            "Miniroom_floor01.dds",
            "Miniroom_floor02.dds",
            ..Enumerable.Range(1, 99).Select(x => $"etc_elec{x:00}.tga"),
            "etc_Laser01.tga",
            "etc_Particle2.bmp",
            "etc_Particle11.bmp",
            "etc_Particle12.bmp",
            "etc_Particle13.bmp",
            "etc_Particle14.bmp",
            "etc_Tail2.bmp",
            "etc_Tail1.bmp",
            "etc_reflect.tga",
            "etc_ParticleCloud01.bmp"
            ];

        public static string[] ModelFilenameRoot => _modelFilenameRoot;
    }
}
