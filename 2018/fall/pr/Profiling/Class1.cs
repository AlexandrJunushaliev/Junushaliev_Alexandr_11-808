﻿
using Profiling;
using System;

struct S1
{
    byte Value0;
}

class C1
{
    byte Value0;
}

struct S2
{
    byte Value0; byte Value1;
}

class C2
{
    byte Value0; byte Value1;
}

struct S4
{
    byte Value0; byte Value1; byte Value2; byte Value3;
}

class C4
{
    byte Value0; byte Value1; byte Value2; byte Value3;
}

struct S8
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7;
}

class C8
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7;
}

struct S16
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15;
}

class C16
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15;
}

struct S32
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31;
}

class C32
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31;
}

struct S64
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31; byte Value32; byte Value33; byte Value34; byte Value35; byte Value36; byte Value37; byte Value38; byte Value39; byte Value40; byte Value41; byte Value42; byte Value43; byte Value44; byte Value45; byte Value46; byte Value47; byte Value48; byte Value49; byte Value50; byte Value51; byte Value52; byte Value53; byte Value54; byte Value55; byte Value56; byte Value57; byte Value58; byte Value59; byte Value60; byte Value61; byte Value62; byte Value63;
}

class C64
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31; byte Value32; byte Value33; byte Value34; byte Value35; byte Value36; byte Value37; byte Value38; byte Value39; byte Value40; byte Value41; byte Value42; byte Value43; byte Value44; byte Value45; byte Value46; byte Value47; byte Value48; byte Value49; byte Value50; byte Value51; byte Value52; byte Value53; byte Value54; byte Value55; byte Value56; byte Value57; byte Value58; byte Value59; byte Value60; byte Value61; byte Value62; byte Value63;
}

struct S128
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31; byte Value32; byte Value33; byte Value34; byte Value35; byte Value36; byte Value37; byte Value38; byte Value39; byte Value40; byte Value41; byte Value42; byte Value43; byte Value44; byte Value45; byte Value46; byte Value47; byte Value48; byte Value49; byte Value50; byte Value51; byte Value52; byte Value53; byte Value54; byte Value55; byte Value56; byte Value57; byte Value58; byte Value59; byte Value60; byte Value61; byte Value62; byte Value63; byte Value64; byte Value65; byte Value66; byte Value67; byte Value68; byte Value69; byte Value70; byte Value71; byte Value72; byte Value73; byte Value74; byte Value75; byte Value76; byte Value77; byte Value78; byte Value79; byte Value80; byte Value81; byte Value82; byte Value83; byte Value84; byte Value85; byte Value86; byte Value87; byte Value88; byte Value89; byte Value90; byte Value91; byte Value92; byte Value93; byte Value94; byte Value95; byte Value96; byte Value97; byte Value98; byte Value99; byte Value100; byte Value101; byte Value102; byte Value103; byte Value104; byte Value105; byte Value106; byte Value107; byte Value108; byte Value109; byte Value110; byte Value111; byte Value112; byte Value113; byte Value114; byte Value115; byte Value116; byte Value117; byte Value118; byte Value119; byte Value120; byte Value121; byte Value122; byte Value123; byte Value124; byte Value125; byte Value126; byte Value127;
}

class C128
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31; byte Value32; byte Value33; byte Value34; byte Value35; byte Value36; byte Value37; byte Value38; byte Value39; byte Value40; byte Value41; byte Value42; byte Value43; byte Value44; byte Value45; byte Value46; byte Value47; byte Value48; byte Value49; byte Value50; byte Value51; byte Value52; byte Value53; byte Value54; byte Value55; byte Value56; byte Value57; byte Value58; byte Value59; byte Value60; byte Value61; byte Value62; byte Value63; byte Value64; byte Value65; byte Value66; byte Value67; byte Value68; byte Value69; byte Value70; byte Value71; byte Value72; byte Value73; byte Value74; byte Value75; byte Value76; byte Value77; byte Value78; byte Value79; byte Value80; byte Value81; byte Value82; byte Value83; byte Value84; byte Value85; byte Value86; byte Value87; byte Value88; byte Value89; byte Value90; byte Value91; byte Value92; byte Value93; byte Value94; byte Value95; byte Value96; byte Value97; byte Value98; byte Value99; byte Value100; byte Value101; byte Value102; byte Value103; byte Value104; byte Value105; byte Value106; byte Value107; byte Value108; byte Value109; byte Value110; byte Value111; byte Value112; byte Value113; byte Value114; byte Value115; byte Value116; byte Value117; byte Value118; byte Value119; byte Value120; byte Value121; byte Value122; byte Value123; byte Value124; byte Value125; byte Value126; byte Value127;
}

struct S256
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31; byte Value32; byte Value33; byte Value34; byte Value35; byte Value36; byte Value37; byte Value38; byte Value39; byte Value40; byte Value41; byte Value42; byte Value43; byte Value44; byte Value45; byte Value46; byte Value47; byte Value48; byte Value49; byte Value50; byte Value51; byte Value52; byte Value53; byte Value54; byte Value55; byte Value56; byte Value57; byte Value58; byte Value59; byte Value60; byte Value61; byte Value62; byte Value63; byte Value64; byte Value65; byte Value66; byte Value67; byte Value68; byte Value69; byte Value70; byte Value71; byte Value72; byte Value73; byte Value74; byte Value75; byte Value76; byte Value77; byte Value78; byte Value79; byte Value80; byte Value81; byte Value82; byte Value83; byte Value84; byte Value85; byte Value86; byte Value87; byte Value88; byte Value89; byte Value90; byte Value91; byte Value92; byte Value93; byte Value94; byte Value95; byte Value96; byte Value97; byte Value98; byte Value99; byte Value100; byte Value101; byte Value102; byte Value103; byte Value104; byte Value105; byte Value106; byte Value107; byte Value108; byte Value109; byte Value110; byte Value111; byte Value112; byte Value113; byte Value114; byte Value115; byte Value116; byte Value117; byte Value118; byte Value119; byte Value120; byte Value121; byte Value122; byte Value123; byte Value124; byte Value125; byte Value126; byte Value127; byte Value128; byte Value129; byte Value130; byte Value131; byte Value132; byte Value133; byte Value134; byte Value135; byte Value136; byte Value137; byte Value138; byte Value139; byte Value140; byte Value141; byte Value142; byte Value143; byte Value144; byte Value145; byte Value146; byte Value147; byte Value148; byte Value149; byte Value150; byte Value151; byte Value152; byte Value153; byte Value154; byte Value155; byte Value156; byte Value157; byte Value158; byte Value159; byte Value160; byte Value161; byte Value162; byte Value163; byte Value164; byte Value165; byte Value166; byte Value167; byte Value168; byte Value169; byte Value170; byte Value171; byte Value172; byte Value173; byte Value174; byte Value175; byte Value176; byte Value177; byte Value178; byte Value179; byte Value180; byte Value181; byte Value182; byte Value183; byte Value184; byte Value185; byte Value186; byte Value187; byte Value188; byte Value189; byte Value190; byte Value191; byte Value192; byte Value193; byte Value194; byte Value195; byte Value196; byte Value197; byte Value198; byte Value199; byte Value200; byte Value201; byte Value202; byte Value203; byte Value204; byte Value205; byte Value206; byte Value207; byte Value208; byte Value209; byte Value210; byte Value211; byte Value212; byte Value213; byte Value214; byte Value215; byte Value216; byte Value217; byte Value218; byte Value219; byte Value220; byte Value221; byte Value222; byte Value223; byte Value224; byte Value225; byte Value226; byte Value227; byte Value228; byte Value229; byte Value230; byte Value231; byte Value232; byte Value233; byte Value234; byte Value235; byte Value236; byte Value237; byte Value238; byte Value239; byte Value240; byte Value241; byte Value242; byte Value243; byte Value244; byte Value245; byte Value246; byte Value247; byte Value248; byte Value249; byte Value250; byte Value251; byte Value252; byte Value253; byte Value254; byte Value255;
}

class C256
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31; byte Value32; byte Value33; byte Value34; byte Value35; byte Value36; byte Value37; byte Value38; byte Value39; byte Value40; byte Value41; byte Value42; byte Value43; byte Value44; byte Value45; byte Value46; byte Value47; byte Value48; byte Value49; byte Value50; byte Value51; byte Value52; byte Value53; byte Value54; byte Value55; byte Value56; byte Value57; byte Value58; byte Value59; byte Value60; byte Value61; byte Value62; byte Value63; byte Value64; byte Value65; byte Value66; byte Value67; byte Value68; byte Value69; byte Value70; byte Value71; byte Value72; byte Value73; byte Value74; byte Value75; byte Value76; byte Value77; byte Value78; byte Value79; byte Value80; byte Value81; byte Value82; byte Value83; byte Value84; byte Value85; byte Value86; byte Value87; byte Value88; byte Value89; byte Value90; byte Value91; byte Value92; byte Value93; byte Value94; byte Value95; byte Value96; byte Value97; byte Value98; byte Value99; byte Value100; byte Value101; byte Value102; byte Value103; byte Value104; byte Value105; byte Value106; byte Value107; byte Value108; byte Value109; byte Value110; byte Value111; byte Value112; byte Value113; byte Value114; byte Value115; byte Value116; byte Value117; byte Value118; byte Value119; byte Value120; byte Value121; byte Value122; byte Value123; byte Value124; byte Value125; byte Value126; byte Value127; byte Value128; byte Value129; byte Value130; byte Value131; byte Value132; byte Value133; byte Value134; byte Value135; byte Value136; byte Value137; byte Value138; byte Value139; byte Value140; byte Value141; byte Value142; byte Value143; byte Value144; byte Value145; byte Value146; byte Value147; byte Value148; byte Value149; byte Value150; byte Value151; byte Value152; byte Value153; byte Value154; byte Value155; byte Value156; byte Value157; byte Value158; byte Value159; byte Value160; byte Value161; byte Value162; byte Value163; byte Value164; byte Value165; byte Value166; byte Value167; byte Value168; byte Value169; byte Value170; byte Value171; byte Value172; byte Value173; byte Value174; byte Value175; byte Value176; byte Value177; byte Value178; byte Value179; byte Value180; byte Value181; byte Value182; byte Value183; byte Value184; byte Value185; byte Value186; byte Value187; byte Value188; byte Value189; byte Value190; byte Value191; byte Value192; byte Value193; byte Value194; byte Value195; byte Value196; byte Value197; byte Value198; byte Value199; byte Value200; byte Value201; byte Value202; byte Value203; byte Value204; byte Value205; byte Value206; byte Value207; byte Value208; byte Value209; byte Value210; byte Value211; byte Value212; byte Value213; byte Value214; byte Value215; byte Value216; byte Value217; byte Value218; byte Value219; byte Value220; byte Value221; byte Value222; byte Value223; byte Value224; byte Value225; byte Value226; byte Value227; byte Value228; byte Value229; byte Value230; byte Value231; byte Value232; byte Value233; byte Value234; byte Value235; byte Value236; byte Value237; byte Value238; byte Value239; byte Value240; byte Value241; byte Value242; byte Value243; byte Value244; byte Value245; byte Value246; byte Value247; byte Value248; byte Value249; byte Value250; byte Value251; byte Value252; byte Value253; byte Value254; byte Value255;
}

struct S512
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31; byte Value32; byte Value33; byte Value34; byte Value35; byte Value36; byte Value37; byte Value38; byte Value39; byte Value40; byte Value41; byte Value42; byte Value43; byte Value44; byte Value45; byte Value46; byte Value47; byte Value48; byte Value49; byte Value50; byte Value51; byte Value52; byte Value53; byte Value54; byte Value55; byte Value56; byte Value57; byte Value58; byte Value59; byte Value60; byte Value61; byte Value62; byte Value63; byte Value64; byte Value65; byte Value66; byte Value67; byte Value68; byte Value69; byte Value70; byte Value71; byte Value72; byte Value73; byte Value74; byte Value75; byte Value76; byte Value77; byte Value78; byte Value79; byte Value80; byte Value81; byte Value82; byte Value83; byte Value84; byte Value85; byte Value86; byte Value87; byte Value88; byte Value89; byte Value90; byte Value91; byte Value92; byte Value93; byte Value94; byte Value95; byte Value96; byte Value97; byte Value98; byte Value99; byte Value100; byte Value101; byte Value102; byte Value103; byte Value104; byte Value105; byte Value106; byte Value107; byte Value108; byte Value109; byte Value110; byte Value111; byte Value112; byte Value113; byte Value114; byte Value115; byte Value116; byte Value117; byte Value118; byte Value119; byte Value120; byte Value121; byte Value122; byte Value123; byte Value124; byte Value125; byte Value126; byte Value127; byte Value128; byte Value129; byte Value130; byte Value131; byte Value132; byte Value133; byte Value134; byte Value135; byte Value136; byte Value137; byte Value138; byte Value139; byte Value140; byte Value141; byte Value142; byte Value143; byte Value144; byte Value145; byte Value146; byte Value147; byte Value148; byte Value149; byte Value150; byte Value151; byte Value152; byte Value153; byte Value154; byte Value155; byte Value156; byte Value157; byte Value158; byte Value159; byte Value160; byte Value161; byte Value162; byte Value163; byte Value164; byte Value165; byte Value166; byte Value167; byte Value168; byte Value169; byte Value170; byte Value171; byte Value172; byte Value173; byte Value174; byte Value175; byte Value176; byte Value177; byte Value178; byte Value179; byte Value180; byte Value181; byte Value182; byte Value183; byte Value184; byte Value185; byte Value186; byte Value187; byte Value188; byte Value189; byte Value190; byte Value191; byte Value192; byte Value193; byte Value194; byte Value195; byte Value196; byte Value197; byte Value198; byte Value199; byte Value200; byte Value201; byte Value202; byte Value203; byte Value204; byte Value205; byte Value206; byte Value207; byte Value208; byte Value209; byte Value210; byte Value211; byte Value212; byte Value213; byte Value214; byte Value215; byte Value216; byte Value217; byte Value218; byte Value219; byte Value220; byte Value221; byte Value222; byte Value223; byte Value224; byte Value225; byte Value226; byte Value227; byte Value228; byte Value229; byte Value230; byte Value231; byte Value232; byte Value233; byte Value234; byte Value235; byte Value236; byte Value237; byte Value238; byte Value239; byte Value240; byte Value241; byte Value242; byte Value243; byte Value244; byte Value245; byte Value246; byte Value247; byte Value248; byte Value249; byte Value250; byte Value251; byte Value252; byte Value253; byte Value254; byte Value255; byte Value256; byte Value257; byte Value258; byte Value259; byte Value260; byte Value261; byte Value262; byte Value263; byte Value264; byte Value265; byte Value266; byte Value267; byte Value268; byte Value269; byte Value270; byte Value271; byte Value272; byte Value273; byte Value274; byte Value275; byte Value276; byte Value277; byte Value278; byte Value279; byte Value280; byte Value281; byte Value282; byte Value283; byte Value284; byte Value285; byte Value286; byte Value287; byte Value288; byte Value289; byte Value290; byte Value291; byte Value292; byte Value293; byte Value294; byte Value295; byte Value296; byte Value297; byte Value298; byte Value299; byte Value300; byte Value301; byte Value302; byte Value303; byte Value304; byte Value305; byte Value306; byte Value307; byte Value308; byte Value309; byte Value310; byte Value311; byte Value312; byte Value313; byte Value314; byte Value315; byte Value316; byte Value317; byte Value318; byte Value319; byte Value320; byte Value321; byte Value322; byte Value323; byte Value324; byte Value325; byte Value326; byte Value327; byte Value328; byte Value329; byte Value330; byte Value331; byte Value332; byte Value333; byte Value334; byte Value335; byte Value336; byte Value337; byte Value338; byte Value339; byte Value340; byte Value341; byte Value342; byte Value343; byte Value344; byte Value345; byte Value346; byte Value347; byte Value348; byte Value349; byte Value350; byte Value351; byte Value352; byte Value353; byte Value354; byte Value355; byte Value356; byte Value357; byte Value358; byte Value359; byte Value360; byte Value361; byte Value362; byte Value363; byte Value364; byte Value365; byte Value366; byte Value367; byte Value368; byte Value369; byte Value370; byte Value371; byte Value372; byte Value373; byte Value374; byte Value375; byte Value376; byte Value377; byte Value378; byte Value379; byte Value380; byte Value381; byte Value382; byte Value383; byte Value384; byte Value385; byte Value386; byte Value387; byte Value388; byte Value389; byte Value390; byte Value391; byte Value392; byte Value393; byte Value394; byte Value395; byte Value396; byte Value397; byte Value398; byte Value399; byte Value400; byte Value401; byte Value402; byte Value403; byte Value404; byte Value405; byte Value406; byte Value407; byte Value408; byte Value409; byte Value410; byte Value411; byte Value412; byte Value413; byte Value414; byte Value415; byte Value416; byte Value417; byte Value418; byte Value419; byte Value420; byte Value421; byte Value422; byte Value423; byte Value424; byte Value425; byte Value426; byte Value427; byte Value428; byte Value429; byte Value430; byte Value431; byte Value432; byte Value433; byte Value434; byte Value435; byte Value436; byte Value437; byte Value438; byte Value439; byte Value440; byte Value441; byte Value442; byte Value443; byte Value444; byte Value445; byte Value446; byte Value447; byte Value448; byte Value449; byte Value450; byte Value451; byte Value452; byte Value453; byte Value454; byte Value455; byte Value456; byte Value457; byte Value458; byte Value459; byte Value460; byte Value461; byte Value462; byte Value463; byte Value464; byte Value465; byte Value466; byte Value467; byte Value468; byte Value469; byte Value470; byte Value471; byte Value472; byte Value473; byte Value474; byte Value475; byte Value476; byte Value477; byte Value478; byte Value479; byte Value480; byte Value481; byte Value482; byte Value483; byte Value484; byte Value485; byte Value486; byte Value487; byte Value488; byte Value489; byte Value490; byte Value491; byte Value492; byte Value493; byte Value494; byte Value495; byte Value496; byte Value497; byte Value498; byte Value499; byte Value500; byte Value501; byte Value502; byte Value503; byte Value504; byte Value505; byte Value506; byte Value507; byte Value508; byte Value509; byte Value510; byte Value511;
}

class C512
{
    byte Value0; byte Value1; byte Value2; byte Value3; byte Value4; byte Value5; byte Value6; byte Value7; byte Value8; byte Value9; byte Value10; byte Value11; byte Value12; byte Value13; byte Value14; byte Value15; byte Value16; byte Value17; byte Value18; byte Value19; byte Value20; byte Value21; byte Value22; byte Value23; byte Value24; byte Value25; byte Value26; byte Value27; byte Value28; byte Value29; byte Value30; byte Value31; byte Value32; byte Value33; byte Value34; byte Value35; byte Value36; byte Value37; byte Value38; byte Value39; byte Value40; byte Value41; byte Value42; byte Value43; byte Value44; byte Value45; byte Value46; byte Value47; byte Value48; byte Value49; byte Value50; byte Value51; byte Value52; byte Value53; byte Value54; byte Value55; byte Value56; byte Value57; byte Value58; byte Value59; byte Value60; byte Value61; byte Value62; byte Value63; byte Value64; byte Value65; byte Value66; byte Value67; byte Value68; byte Value69; byte Value70; byte Value71; byte Value72; byte Value73; byte Value74; byte Value75; byte Value76; byte Value77; byte Value78; byte Value79; byte Value80; byte Value81; byte Value82; byte Value83; byte Value84; byte Value85; byte Value86; byte Value87; byte Value88; byte Value89; byte Value90; byte Value91; byte Value92; byte Value93; byte Value94; byte Value95; byte Value96; byte Value97; byte Value98; byte Value99; byte Value100; byte Value101; byte Value102; byte Value103; byte Value104; byte Value105; byte Value106; byte Value107; byte Value108; byte Value109; byte Value110; byte Value111; byte Value112; byte Value113; byte Value114; byte Value115; byte Value116; byte Value117; byte Value118; byte Value119; byte Value120; byte Value121; byte Value122; byte Value123; byte Value124; byte Value125; byte Value126; byte Value127; byte Value128; byte Value129; byte Value130; byte Value131; byte Value132; byte Value133; byte Value134; byte Value135; byte Value136; byte Value137; byte Value138; byte Value139; byte Value140; byte Value141; byte Value142; byte Value143; byte Value144; byte Value145; byte Value146; byte Value147; byte Value148; byte Value149; byte Value150; byte Value151; byte Value152; byte Value153; byte Value154; byte Value155; byte Value156; byte Value157; byte Value158; byte Value159; byte Value160; byte Value161; byte Value162; byte Value163; byte Value164; byte Value165; byte Value166; byte Value167; byte Value168; byte Value169; byte Value170; byte Value171; byte Value172; byte Value173; byte Value174; byte Value175; byte Value176; byte Value177; byte Value178; byte Value179; byte Value180; byte Value181; byte Value182; byte Value183; byte Value184; byte Value185; byte Value186; byte Value187; byte Value188; byte Value189; byte Value190; byte Value191; byte Value192; byte Value193; byte Value194; byte Value195; byte Value196; byte Value197; byte Value198; byte Value199; byte Value200; byte Value201; byte Value202; byte Value203; byte Value204; byte Value205; byte Value206; byte Value207; byte Value208; byte Value209; byte Value210; byte Value211; byte Value212; byte Value213; byte Value214; byte Value215; byte Value216; byte Value217; byte Value218; byte Value219; byte Value220; byte Value221; byte Value222; byte Value223; byte Value224; byte Value225; byte Value226; byte Value227; byte Value228; byte Value229; byte Value230; byte Value231; byte Value232; byte Value233; byte Value234; byte Value235; byte Value236; byte Value237; byte Value238; byte Value239; byte Value240; byte Value241; byte Value242; byte Value243; byte Value244; byte Value245; byte Value246; byte Value247; byte Value248; byte Value249; byte Value250; byte Value251; byte Value252; byte Value253; byte Value254; byte Value255; byte Value256; byte Value257; byte Value258; byte Value259; byte Value260; byte Value261; byte Value262; byte Value263; byte Value264; byte Value265; byte Value266; byte Value267; byte Value268; byte Value269; byte Value270; byte Value271; byte Value272; byte Value273; byte Value274; byte Value275; byte Value276; byte Value277; byte Value278; byte Value279; byte Value280; byte Value281; byte Value282; byte Value283; byte Value284; byte Value285; byte Value286; byte Value287; byte Value288; byte Value289; byte Value290; byte Value291; byte Value292; byte Value293; byte Value294; byte Value295; byte Value296; byte Value297; byte Value298; byte Value299; byte Value300; byte Value301; byte Value302; byte Value303; byte Value304; byte Value305; byte Value306; byte Value307; byte Value308; byte Value309; byte Value310; byte Value311; byte Value312; byte Value313; byte Value314; byte Value315; byte Value316; byte Value317; byte Value318; byte Value319; byte Value320; byte Value321; byte Value322; byte Value323; byte Value324; byte Value325; byte Value326; byte Value327; byte Value328; byte Value329; byte Value330; byte Value331; byte Value332; byte Value333; byte Value334; byte Value335; byte Value336; byte Value337; byte Value338; byte Value339; byte Value340; byte Value341; byte Value342; byte Value343; byte Value344; byte Value345; byte Value346; byte Value347; byte Value348; byte Value349; byte Value350; byte Value351; byte Value352; byte Value353; byte Value354; byte Value355; byte Value356; byte Value357; byte Value358; byte Value359; byte Value360; byte Value361; byte Value362; byte Value363; byte Value364; byte Value365; byte Value366; byte Value367; byte Value368; byte Value369; byte Value370; byte Value371; byte Value372; byte Value373; byte Value374; byte Value375; byte Value376; byte Value377; byte Value378; byte Value379; byte Value380; byte Value381; byte Value382; byte Value383; byte Value384; byte Value385; byte Value386; byte Value387; byte Value388; byte Value389; byte Value390; byte Value391; byte Value392; byte Value393; byte Value394; byte Value395; byte Value396; byte Value397; byte Value398; byte Value399; byte Value400; byte Value401; byte Value402; byte Value403; byte Value404; byte Value405; byte Value406; byte Value407; byte Value408; byte Value409; byte Value410; byte Value411; byte Value412; byte Value413; byte Value414; byte Value415; byte Value416; byte Value417; byte Value418; byte Value419; byte Value420; byte Value421; byte Value422; byte Value423; byte Value424; byte Value425; byte Value426; byte Value427; byte Value428; byte Value429; byte Value430; byte Value431; byte Value432; byte Value433; byte Value434; byte Value435; byte Value436; byte Value437; byte Value438; byte Value439; byte Value440; byte Value441; byte Value442; byte Value443; byte Value444; byte Value445; byte Value446; byte Value447; byte Value448; byte Value449; byte Value450; byte Value451; byte Value452; byte Value453; byte Value454; byte Value455; byte Value456; byte Value457; byte Value458; byte Value459; byte Value460; byte Value461; byte Value462; byte Value463; byte Value464; byte Value465; byte Value466; byte Value467; byte Value468; byte Value469; byte Value470; byte Value471; byte Value472; byte Value473; byte Value474; byte Value475; byte Value476; byte Value477; byte Value478; byte Value479; byte Value480; byte Value481; byte Value482; byte Value483; byte Value484; byte Value485; byte Value486; byte Value487; byte Value488; byte Value489; byte Value490; byte Value491; byte Value492; byte Value493; byte Value494; byte Value495; byte Value496; byte Value497; byte Value498; byte Value499; byte Value500; byte Value501; byte Value502; byte Value503; byte Value504; byte Value505; byte Value506; byte Value507; byte Value508; byte Value509; byte Value510; byte Value511;
}


public class ArrayRunner : IRunner
{
    void PC1()
    {
        var array = new C1[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C1();
    }
    void PS1()
    {
        var array = new S1[Constants.ArraySize];
    }
    void PC2()
    {
        var array = new C2[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C2();
    }
    void PS2()
    {
        var array = new S2[Constants.ArraySize];
    }
    void PC4()
    {
        var array = new C4[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C4();
    }
    void PS4()
    {
        var array = new S4[Constants.ArraySize];
    }
    void PC8()
    {
        var array = new C8[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C8();
    }
    void PS8()
    {
        var array = new S8[Constants.ArraySize];
    }
    void PC16()
    {
        var array = new C16[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C16();
    }
    void PS16()
    {
        var array = new S16[Constants.ArraySize];
    }
    void PC32()
    {
        var array = new C32[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C32();
    }
    void PS32()
    {
        var array = new S32[Constants.ArraySize];
    }
    void PC64()
    {
        var array = new C64[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C64();
    }
    void PS64()
    {
        var array = new S64[Constants.ArraySize];
    }
    void PC128()
    {
        var array = new C128[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C128();
    }
    void PS128()
    {
        var array = new S128[Constants.ArraySize];
    }
    void PC256()
    {
        var array = new C256[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C256();
    }
    void PS256()
    {
        var array = new S256[Constants.ArraySize];
    }
    void PC512()
    {
        var array = new C512[Constants.ArraySize];
        for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C512();
    }
    void PS512()
    {
        var array = new S512[Constants.ArraySize];
    }

    public void Call(bool isClass, int size, int count)
    {
        if (isClass && size == 1)
        {
            for (int i = 0; i < count; i++) PC1();
            return;
        }
        if (!isClass && size == 1)
        {
            for (int i = 0; i < count; i++) PS1();
            return;
        }
        if (isClass && size == 2)
        {
            for (int i = 0; i < count; i++) PC2();
            return;
        }
        if (!isClass && size == 2)
        {
            for (int i = 0; i < count; i++) PS2();
            return;
        }
        if (isClass && size == 4)
        {
            for (int i = 0; i < count; i++) PC4();
            return;
        }
        if (!isClass && size == 4)
        {
            for (int i = 0; i < count; i++) PS4();
            return;
        }
        if (isClass && size == 8)
        {
            for (int i = 0; i < count; i++) PC8();
            return;
        }
        if (!isClass && size == 8)
        {
            for (int i = 0; i < count; i++) PS8();
            return;
        }
        if (isClass && size == 16)
        {
            for (int i = 0; i < count; i++) PC16();
            return;
        }
        if (!isClass && size == 16)
        {
            for (int i = 0; i < count; i++) PS16();
            return;
        }
        if (isClass && size == 32)
        {
            for (int i = 0; i < count; i++) PC32();
            return;
        }
        if (!isClass && size == 32)
        {
            for (int i = 0; i < count; i++) PS32();
            return;
        }
        if (isClass && size == 64)
        {
            for (int i = 0; i < count; i++) PC64();
            return;
        }
        if (!isClass && size == 64)
        {
            for (int i = 0; i < count; i++) PS64();
            return;
        }
        if (isClass && size == 128)
        {
            for (int i = 0; i < count; i++) PC128();
            return;
        }
        if (!isClass && size == 128)
        {
            for (int i = 0; i < count; i++) PS128();
            return;
        }
        if (isClass && size == 256)
        {
            for (int i = 0; i < count; i++) PC256();
            return;
        }
        if (!isClass && size == 256)
        {
            for (int i = 0; i < count; i++) PS256();
            return;
        }
        if (isClass && size == 512)
        {
            for (int i = 0; i < count; i++) PC512();
            return;
        }
        if (!isClass && size == 512)
        {
            for (int i = 0; i < count; i++) PC512();
            return;
        }
        throw new ArgumentException();
    }
}