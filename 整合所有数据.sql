drop table BasicData 

select Owner.ID ID,Sex 性别,IDCard 身份证号,Age 年龄,Job 职位,WorkUnit 工作单位,Weight 体重, HeadHeight 头高,HeadWidth 头宽,HeadLength 头长,HeadGirth 头围,CrownShapeAround 头冠状围,BitragionIntertragicArc 耳屏间弧,HeadSagittalArc 头矢状弧,BrowTopNeckArcLength 眉间顶颈弧长,MorphoGicalFacialLength 形态面长,InterpupillaryDistance 瞳孔间距,CervixThickness 颈根厚,MidNeckGirth 颈中围,NeckGirth 颈围,ShoulderAcross 肩宽,LeftShoulder 左肩宽,RightShoulder 右肩宽,LeftShoulderAngle 左肩斜,RightShoulderAngle 右肩斜,AcrossFront 前胸宽,MilkInterval 乳间距,NeckPointToBbustProminenceLeft 前颈点到乳峰长左,NeckPointToBustProminenceRight 前颈点到乳峰长右,Bust 胸围,ThoracicCavityBand 胸腔带围,UnderBustGirth 胸下围,AcrossBack 后背宽,ChestThickness 胸厚,Waist 腰围,WaistBackLevelDifference 腰背水平差,HipThickness 臀厚,AdominalThickness 腹围厚,HipGirth 上臀围,ButtockGirth 臀围,MaximumHipGirth 臀部后突围,Belly 腹围,MaximumBellyCircamference 腹部前突围,WaistPelvisDistance 腰臀距后,WaistPelvisLengthLeft 腰臀长左,WaistPelvisLengthRight 腰臀长右,WaistUnderarmLeft 上体侧躯干长左,WaistUnderarmRight 上体侧躯干长右,BodyHigh 身高,CervicalHeight 颈椎点高,CervicalHip 颈臀距,CervicalHeightKnee 颈膝距,CervicalWaist 背长,ScapulaHeight 肩胛骨高,BreastHeight 胸围高,NeckFrontHeight 前颈点高,CervicalWristLengthLeft 全臂长左,CervicalWristLengthRight 全臂长右,ArmLengthLeft 臂长左,ArmLengthRight 臂长右,UpperArmLengthLeft 上臂长左,UpperArmLengthRight 上臂长右,UpperArmGirthLeft 上臂围左,UpperArmGirthRight 上臂围右,WristGirthLeft 腕围左,WristGirthRight 腕围右,HandThickness 掌厚,HandGirth 掌围,InsideLegLengthLeft 腿内侧长左,InsideLegLengthRight 腿内侧长右,SideLengthToWaistLeft 腿外侧长左,SideLengthToWaistRight 腿外侧长右,LateralHeightOfWaistLeft 腿外侧缝长左,LateralHeightOfWaistRight 腿外侧缝长右,ThighGirthLeft 大臀围左,ThighGirthRight 大臀围右,KneeGirthLeft 膝围左,KneeGirthRight 膝围右,CalfGirthLeft 腿肚围左,CalfGirthRight 腿肚围右,AnkleGirthLeft 踝围左,AnkleGirthRight 踝围右,WaistKnee 腰膝距,WaistHeight 腰高,HipHeight 臀高,MaximumHipHeight 臀后突点高,CrothHeight 会阴高,BellyHeight 腹高,MaximuBellyHeight 腹部前突点高,CrothToWaistband 股上长,CrothLength 会阴上部前后长,FootLength 足长,FootWidth 足宽,FootGirth 足围,ToeHeihet 足趾高,FootTarsiHigh 跗骨点高,MedialMalleolusHigh 内踝高,LateralMalleolusHigh 外踝高 
 into BasicData
 from
 Owner
 
 left outer join ChestData on Owner.ID = ChestData.ID 
 left outer join FootData on ChestData.ID = FootData.ID 
 left outer join HeaderData on FootData.ID = HeaderData.ID 
 left outer join LowerLimbsData on HeaderData.ID = LowerLimbsData.ID 
 left outer join NeckData on LowerLimbsData.ID = NeckData.ID 
 left outer join BellyWaistHipData on NeckData.ID = BellyWaistHipData.ID 
 left outer join ShoulderData on Owner.ID = ShoulderData.ID 
 left outer join TrunkIntegralData on ShoulderData.ID = TrunkIntegralData.ID 
 left outer join UpperLimbsData on TrunkIntegralData.ID = UpperLimbsData.ID 