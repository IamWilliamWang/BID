using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//引用类库
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace BID.BaseClass
{
    class BaseInfo
    {
        BaseClass.DataBase MyDataClass = new BID.BaseClass.DataBase();//声明MyMeans类的一个对象，以调用其方法
        public static string ADDs = "";  //用来存储添加或修改的SQL语句
        public static string BasicData_ID = "";  //存储数据添加修改时的ID编号
        public static string FindValue = "";  //存储查询条件
        DataBase data = new DataBase();//创建DataBase类的对象

        

        //基础数据查询修改添加删除
        #region 查询基础数据信息
        /// <summary>
        /// 根据--编号--得到被测人的基础数据信息
        /// </summary>
        /// <param name="BasicData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindBasicDataByID(cBasicDataInfo BasicData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, BasicData.id+"%"),
            };
            return (data.RunProcReturn("select * from BasicData where ID like @ID", prams, tbName));
        }
        /// <summary>
        /// 根据--性别--得到被测人的基础数据信息
        /// </summary>
        /// <param name="BasicData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindBasicDataBySex(cBasicDataInfo BasicData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@Sex",  SqlDbType.VarChar, 50, BasicData.sex+"%"),
            };
            return (data.RunProcReturn("select * from BasicData where Sex like @Sex", prams, tbName));
        }

        internal void CoPassData(ComboBox cmbID, string v1, int v2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据--年龄--得到被测人的基础数据信息
        /// </summary>
        /// <param name="BasicData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindBasicDataByAge(cBasicDataInfo BasicData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@Age",  SqlDbType.VarChar,100, BasicData.age+"%"),
            };
            return (data.RunProcReturn("select * from BasicData where Age like @Age", prams, tbName));
        }
        /// <summary>
        /// 根据--身高--得到被测人的基础数据信息
        /// </summary>
        /// <param name="BasicData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindBasicDataByBodyHigh(cBasicDataInfo BasicData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@BodyHigh",  SqlDbType.VarChar, 200, BasicData.bodyhigh+"%"),
            };
            return (data.RunProcReturn("select * from BasicData where BodyHigh like @BodyHigh", prams, tbName));
        }
        /// <summary>
        /// 根据--身份证前6位--得到被测人的基础数据信息
        /// </summary>
        /// <param name="BasicData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindBasicDataByIDCard(cBasicDataInfo BasicData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@IDCard",  SqlDbType.VarChar, 200, BasicData.idcard+"%"),
            };
            return (data.RunProcReturn("select * from BasicData where IDCard like @IDCard", prams, tbName));
        }

        /// <summary>
        /// 得到被测人的基础数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllBasicData(string tbName)
        {
            return (data.RunProcReturn("select * from BasicData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--基础数据信息信息
        /// <summary>
        /// 添加--基础数据--信息
        /// </summary>
        /// <param name="BasicData"></param>
        /// <returns></returns>
        public int AddBasicData(cBasicDataInfo BasicData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, BasicData.id),
                                        data.MakeInParam("@Sex",  SqlDbType.VarChar, 50,BasicData.sex),
                                        data.MakeInParam("@IDCard",  SqlDbType.VarChar,50, BasicData.idcard),
                                        data.MakeInParam("@Age",  SqlDbType.Float, 100, BasicData.age),
                                        data.MakeInParam("@BodyHigh",  SqlDbType.Float, 200, BasicData.bodyhigh),

            };
            return (data.RunProc("INSERT INTO BasicData (ID,Sex,IDCard,Age,BodyHigh) VALUES (@ID,@Sex,@IDCard,@Age,@BodyHigh)", prams));
        }
        #endregion

        #region 修改--基础数据信息
        /// <summary>
        /// 修改基础数据信息
        /// </summary>
        /// <param name="BasicData"></param>
        /// <returns></returns>
        public int UpdateBasicData(cBasicDataInfo BasicData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, BasicData.id),
                                        data.MakeInParam("@Sex",  SqlDbType.VarChar, 50,BasicData.sex),
                                        data.MakeInParam("@IDCard",  SqlDbType.VarChar,50, BasicData.idcard),
                                        data.MakeInParam("@Age",  SqlDbType.VarChar, 100, BasicData.age),
                                        data.MakeInParam("@BodyHigh",  SqlDbType.VarChar, 200, BasicData.bodyhigh),

            };
            return (data.RunProc("update BasicData set ID=@ID,Sex=@Sex,IDCard=@IDCard,Age=@Age,BodyHigh=@BodyHigh where ID=@ID", prams));
        }
        #endregion

        #region 删除--基础数据信息
        /// <summary>
        /// 删除基础数据
        /// </summary>
        /// <param name="BasicData"></param>
        /// <returns>返回基础数据id</returns>
        public int DeleteBasicData(cBasicDataInfo BasicData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, BasicData.id),
            };
            return (data.RunProc("delete from BasicData where ID=@ID", prams));
        }
        #endregion

        //Owner数据查询修改添加删除
        #region 查询头部数据信息
        /// <summary>
        /// 根据--编号--得到Owner数据信息
        /// </summary>
        /// <param name="Owner"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindOwnerByID(cOwnerInfo Owner, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, Owner.id+"%"),
            };
            return (data.RunProcReturn("select * from [Owner] where [ID] like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到Owner数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllOwner(string tbName)
        {
            return (data.RunProcReturn("select * from [Owner] ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--Owner数据信息信息
        /// <summary>
        /// 添加--Owner数据--信息
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns></returns>
        public int AddOwner(cOwnerInfo Owner)
        {
            SqlParameter[] prams = {
                                       data.MakeInParam("@ID",  SqlDbType.VarChar, 50, Owner.id),
                                        data.MakeInParam("@Sex",  SqlDbType.VarChar, 50,Owner.sex),
                                        data.MakeInParam("@IDCard",  SqlDbType.VarChar,50, Owner.idcard),
                                        data.MakeInParam("@Age",  SqlDbType.Float, 100, Owner.age),
                                        data.MakeInParam("@Job",  SqlDbType.VarChar,50, Owner.job),
                                        data.MakeInParam("@WorkUnit",  SqlDbType.VarChar,50, Owner.workUnit),
                                        data.MakeInParam("@Weight",  SqlDbType.Float, 200, Owner.weight),

            };
            return (data.RunProc("INSERT INTO Owner (ID,Sex,IDCard,Age,Job,WorkUnit,Weight) VALUES (@ID,@Sex,@IDCard,@Age,@Job,@WorkUnit,@Weight)", prams));
        }
        #endregion

        #region 修改--Owner数据信息
        /// <summary>
        /// 修改Owner数据信息
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns></returns>
        public int UpdateOwner(cOwnerInfo Owner)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, Owner.id),
                                        data.MakeInParam("@Sex",  SqlDbType.VarChar, 50,Owner.sex),
                                        data.MakeInParam("@IDCard",  SqlDbType.VarChar,50, Owner.idcard),
                                        data.MakeInParam("@Age",  SqlDbType.Float, 100, Owner.age),
                                        data.MakeInParam("@Job",  SqlDbType.VarChar,50, Owner.job),
                                        data.MakeInParam("@WorkUnit",  SqlDbType.VarChar,50, Owner.workUnit),
                                        data.MakeInParam("@Weight",  SqlDbType.Float, 200, Owner.weight),

            };
            return (data.RunProc("update [Owner] set ID=@ID,Sex=@Sex,IDCard=@IDCard,Age=@Age,Job=@Job,WorkUnit=@WorkUnit,Weight=@Weight where ID=@ID", prams));
        }
        #endregion

        #region 删除--Owner数据信息
        /// <summary>
        /// 删除Owner数据
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns>返回Owner数据id</returns>
        public int DeleteOwner(cOwnerInfo Owner)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, Owner.id),
            };
            return (data.RunProc("delete from [Owner] where ID=@ID", prams));
        }
        #endregion

        //头部数据查询修改添加删除
        #region 查询头部数据信息
        /// <summary>
        /// 根据--编号--得到头部数据信息
        /// </summary>
        /// <param name="HeaderData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindHeaderDataByID(cHeaderDataInfo HeaderData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, HeaderData.id+"%"),
            };
            return (data.RunProcReturn("select * from HeaderData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到头部数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllHeaderData(string tbName)
        {
            return (data.RunProcReturn("select * from HeaderData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--头部数据信息
        /// <summary>
        /// 添加--头部数据--信息
        /// </summary>
        /// <param name="HeaderData"></param>
        /// <returns></returns>
        public int AddHeaderData(cHeaderDataInfo HeaderData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, HeaderData.id),
                                        data.MakeInParam("@HeadHeight",  SqlDbType.Float, 50,HeaderData.headHeight),
                                        data.MakeInParam("@HeadWidth",  SqlDbType.Float,50, HeaderData.headWidth),
                                        data.MakeInParam("@HeadLength",  SqlDbType.Float, 50, HeaderData.headLength),
                                        data.MakeInParam("@HeadGirth",  SqlDbType.Float, 50, HeaderData.headGirth),
                                        data.MakeInParam("@CrownShapeAround",  SqlDbType.Float, 50, HeaderData.crownShapeAround),
                                        data.MakeInParam("@BitragionIntertragicArc",  SqlDbType.Float, 50,HeaderData.bitragionIntertragicArc),
                                        data.MakeInParam("@HeadSagittalArc",  SqlDbType.Float,50, HeaderData.headSagittalArc),
                                        data.MakeInParam("@BrowTopNeckArcLength",  SqlDbType.Float, 50, HeaderData.browTopNeckArcLength),
                                        data.MakeInParam("@MorphoGicalFacialLength",  SqlDbType.Float, 50, HeaderData.morphoGicalFacialLength),
                                        data.MakeInParam("@InterpupillaryDistance",  SqlDbType.Float, 50, HeaderData.interpupillaryDistance),

            };
            return (data.RunProc("INSERT INTO HeaderData (ID,HeadHeight,HeadWidth,HeadLength,HeadGirth,CrownShapeAround,BitragionIntertragicArc,HeadSagittalArc,BrowTopNeckArcLength,MorphoGicalFacialLength,InterpupillaryDistance) VALUES (@ID,@HeadHeight,@HeadWidth,@HeadLength,@HeadGirth,@CrownShapeAround,@BitragionIntertragicArc,@HeadSagittalArc,@BrowTopNeckArcLength,@MorphoGicalFacialLength,@InterpupillaryDistance)", prams));
        }
        #endregion

        #region 修改--头部数据信息
        /// <summary>
        /// 修改头部数据信息
        /// </summary>
        /// <param name="HeaderData"></param>
        /// <returns></returns>
        public int UpdateHeaderData(cHeaderDataInfo HeaderData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, HeaderData.id),
                                        data.MakeInParam("@HeadHeight",  SqlDbType.Float, 50,HeaderData.headHeight),
                                        data.MakeInParam("@HeadWidth",  SqlDbType.Float,50, HeaderData.headWidth),
                                        data.MakeInParam("@HeadLength",  SqlDbType.Float, 50, HeaderData.headLength),
                                        data.MakeInParam("@HeadGirth",  SqlDbType.Float, 50, HeaderData.headGirth),
                                        data.MakeInParam("@CrownShapeAround",  SqlDbType.Float, 50, HeaderData.crownShapeAround),
                                        data.MakeInParam("@BitragionIntertragicArc",  SqlDbType.Float, 50,HeaderData.bitragionIntertragicArc),
                                        data.MakeInParam("@HeadSagittalArc",  SqlDbType.Float,50, HeaderData.headSagittalArc),
                                        data.MakeInParam("@BrowTopNeckArcLength",  SqlDbType.Float, 50, HeaderData.browTopNeckArcLength),
                                        data.MakeInParam("@MorphoGicalFacialLength",  SqlDbType.Float, 50, HeaderData.morphoGicalFacialLength),
                                        data.MakeInParam("@InterpupillaryDistance",  SqlDbType.Float, 50, HeaderData.interpupillaryDistance),

            };
            return (data.RunProc("update HeaderData set ID=@ID,HeadHeight=@HeadHeight,HeadWidth=@HeadWidth,HeadLength=@HeadLength,HeadGirth=@HeadGirth,CrownShapeAround=@CrownShapeAround,BitragionIntertragicArc=@BitragionIntertragicArc,HeadSagittalArc=@HeadSagittalArc,BrowTopNeckArcLength=@BrowTopNeckArcLength,MorphoGicalFacialLength=@MorphoGicalFacialLength,InterpupillaryDistance=@InterpupillaryDistance where ID=@ID", prams));
        }
        #endregion

        #region 删除-头部数据信息
        /// <summary>
        /// 删除头部数据
        /// </summary>
        /// <param name="HeaderData"></param>
        /// <returns>返回头部数据id</returns>
        public int DeleteHeaderData(cHeaderDataInfo HeaderData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, HeaderData.id),
            };
            return (data.RunProc("delete from HeaderData where ID=@ID", prams));
        }
        #endregion

        //颈部数据查询修改添加删除
        #region 查询颈部数据信息
        /// <summary>
        /// 根据--编号--得到颈部数据信息
        /// </summary>
        /// <param name="NeckData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindNeckDataByID(cNeckDataInfo NeckData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, NeckData.id+"%"),
            };
            return (data.RunProcReturn("select * from NeckData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到颈部数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllNeckData(string tbName)
        {
            return (data.RunProcReturn("select * from NeckData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--颈部数据信息
        /// <summary>
        /// 添加--颈部数据--信息
        /// </summary>
        /// <param name="NeckData"></param>
        /// <returns></returns>
        public int AddNeckData(cNeckDataInfo NeckData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, NeckData.id),
                                        data.MakeInParam("@CervixThickness",  SqlDbType.Float, 50,NeckData.cervixThickness),
                                        data.MakeInParam("@MidNeckGirth",  SqlDbType.Float,50, NeckData.midNeckGirth),
                                        data.MakeInParam("@NeckGirth",  SqlDbType.Float, 50, NeckData.neckGirth),

            };
            return (data.RunProc("INSERT INTO NeckData (ID,CervixThickness,MidNeckGirth,NeckGirth) VALUES (@ID,@CervixThickness,@MidNeckGirth,@NeckGirth)", prams));
        }
        #endregion

        #region 修改--颈部数据信息
        /// <summary>
        /// 修改颈部数据信息
        /// </summary>
        /// <param name="NeckData"></param>
        /// <returns></returns>
        public int UpdateNeckData(cNeckDataInfo NeckData)
        {
            SqlParameter[] prams = {
                                       data.MakeInParam("@ID",  SqlDbType.VarChar, 50, NeckData.id),
                                        data.MakeInParam("@CervixThickness",  SqlDbType.Float, 50,NeckData.cervixThickness),
                                        data.MakeInParam("@MidNeckGirth",  SqlDbType.Float,50, NeckData.midNeckGirth),
                                        data.MakeInParam("@NeckGirth",  SqlDbType.Float, 50, NeckData.neckGirth),
            };
            return (data.RunProc("update NeckData set ID=@ID,CervixThickness=@CervixThickness,MidNeckGirth=@MidNeckGirth,NeckGirth=@NeckGirth where ID=@ID", prams));
        }
        #endregion

        #region 删除-颈部数据信息
        /// <summary>
        /// 删除颈部数据
        /// </summary>
        /// <param name="NeckData"></param>
        /// <returns>返回颈部数据id</returns>
        public int DeleteNeckData(cNeckDataInfo NeckData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, NeckData.id),
            };
            return (data.RunProc("delete from NeckData where ID=@ID", prams));
        }
        #endregion

        //肩部数据查询修改添加删除
        #region 查询肩部数据信息
        /// <summary>
        /// 根据--编号--得到肩部数据信息
        /// </summary>
        /// <param name="ShoulderData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindShoulderDataByID(cShoulderDataInfo ShoulderData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, ShoulderData.id+"%"),
            };
            return (data.RunProcReturn("select * from ShoulderData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到肩部数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllShoulderData(string tbName)
        {
            return (data.RunProcReturn("select * from ShoulderData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--肩部数据信息
        /// <summary>
        /// 添加--肩部数据--信息
        /// </summary>
        /// <param name="ShoulderData"></param>
        /// <returns></returns>
        public int AddShoulderData(cShoulderDataInfo ShoulderData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, ShoulderData.id),
                                        data.MakeInParam("@ShoulderAcross",  SqlDbType.Float, 50,ShoulderData.shoulderAcross),
                                        data.MakeInParam("@LeftShoulder",  SqlDbType.Float,50, ShoulderData.leftShoulder ),
                                        data.MakeInParam("@RightShoulder",  SqlDbType.Float, 50, ShoulderData.rightShoulder),
                                        data.MakeInParam("@LeftShoulderAngle",  SqlDbType.Float, 50, ShoulderData.leftShoulderAngle),
                                        data.MakeInParam("@RightShoulderAngle",  SqlDbType.Float, 50, ShoulderData.rightShoulderAngle),

            };
            return (data.RunProc("INSERT INTO ShoulderData (ID,ShoulderAcross,LeftShoulder,RightShoulder,LeftShoulderAngle,RightShoulderAngle) VALUES (@ID,@ShoulderAcross,@LeftShoulder,@RightShoulder,@LeftShoulderAngle,@RightShoulderAngle)", prams));
        }
        #endregion

        #region 修改--肩部数据信息
        /// <summary>
        /// 修改肩部数据信息
        /// </summary>
        /// <param name="ShoulderData"></param>
        /// <returns></returns>
        public int UpdateShoulderData(cShoulderDataInfo ShoulderData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, ShoulderData.id),
                                        data.MakeInParam("@ShoulderAcross",  SqlDbType.Float, 50,ShoulderData.shoulderAcross),
                                        data.MakeInParam("@LeftShoulder",  SqlDbType.Float,50, ShoulderData.leftShoulder ),
                                        data.MakeInParam("@RightShoulder",  SqlDbType.Float, 50, ShoulderData.rightShoulder),
                                        data.MakeInParam("@LeftShoulderAngle",  SqlDbType.Float, 50, ShoulderData.leftShoulderAngle),
                                        data.MakeInParam("@RightShoulderAngle",  SqlDbType.Float, 50, ShoulderData.rightShoulderAngle),

            };
            return (data.RunProc("update ShoulderData set ID=@ID,ShoulderAcross=@ShoulderAcross,LeftShoulder=@LeftShoulder,RightShoulder=@RightShoulder,LeftShoulderAngle=@LeftShoulderAngle,RightShoulderAngle=@RightShoulderAngle where ID=@ID", prams));
        }
        #endregion

        #region 删除-肩部数据信息
        /// <summary>
        /// 删除肩部数据
        /// </summary>
        /// <param name="ShoulderData"></param>
        /// <returns>返回肩部数据id</returns>
        public int DeleteShoulderData(cShoulderDataInfo ShoulderData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, ShoulderData.id),
            };
            return (data.RunProc("delete from ShoulderData where ID=@ID", prams));
        }
        #endregion

        //胸部数据查询修改添加删除
        #region 查询胸部数据信息
        /// <summary>
        /// 根据--编号--得到胸部数据信息
        /// </summary>
        /// <param name="ChestData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindChestDataByID(cChestDataInfo ChestData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, ChestData.id+"%"),
            };
            return (data.RunProcReturn("select * from ChestData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到胸部数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllChestData(string tbName)
        {
            return (data.RunProcReturn("select * from ChestData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--胸部数据信息
        /// <summary>
        /// 添加--胸部数据--信息
        /// </summary>
        /// <param name="ChestData"></param>
        /// <returns></returns>
        public int AddChestData(cChestDataInfo ChestData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, ChestData.id),
                                        data.MakeInParam("@AcrossFront",  SqlDbType.Float, 50,ChestData.acrossFront),
                                        data.MakeInParam("@MilkInterval",  SqlDbType.Float,50, ChestData.milkInterval),
                                        data.MakeInParam("@NeckPointToBbustProminenceLeft",  SqlDbType.Float, 50, ChestData.neckPointToBbustProminenceLeft),
                                        data.MakeInParam("@NeckPointToBustProminenceRight",  SqlDbType.Float, 50, ChestData.neckPointToBustProminenceRight),
                                        data.MakeInParam("@Bust",  SqlDbType.Float, 50, ChestData.bust),
                                        data.MakeInParam("@ThoracicCavityBand",  SqlDbType.Float,50, ChestData.thoracicCavityBand),
                                        data.MakeInParam("@UnderBustGirth",  SqlDbType.Float, 50, ChestData.underBustGirth),
                                        data.MakeInParam("@AcrossBack",  SqlDbType.Float, 50, ChestData.acrossBack),
                                        data.MakeInParam("@ChestThickness",  SqlDbType.Float, 50, ChestData.chestThickness),

            };
            return (data.RunProc("INSERT INTO ChestData (ID,AcrossFront,MilkInterval,NeckPointToBbustProminenceLeft,NeckPointToBustProminenceRight,Bust,ThoracicCavityBand,UnderBustGirth,AcrossBack,ChestThickness) VALUES (@ID,@AcrossFront,@MilkInterval,@NeckPointToBbustProminenceLeft,@NeckPointToBustProminenceRight,@Bust,@ThoracicCavityBand,@UnderBustGirth,@AcrossBack,@ChestThickness)", prams));
        }
        #endregion

        #region 修改--胸部数据信息
        /// <summary>
        /// 修改胸部数据信息
        /// </summary>
        /// <param name="ChestData"></param>
        /// <returns></returns>
        public int UpdateChestData(cChestDataInfo ChestData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, ChestData.id),
                                        data.MakeInParam("@AcrossFront",  SqlDbType.Float, 50,ChestData.acrossFront),
                                        data.MakeInParam("@MilkInterval",  SqlDbType.Float,50, ChestData.milkInterval),
                                        data.MakeInParam("@NeckPointToBbustProminenceLeft",  SqlDbType.Float, 50, ChestData.neckPointToBbustProminenceLeft),
                                        data.MakeInParam("@NeckPointToBustProminenceRight",  SqlDbType.Float, 50, ChestData.neckPointToBustProminenceRight),
                                        data.MakeInParam("@Bust",  SqlDbType.Float, 50, ChestData.bust),
                                        data.MakeInParam("@ThoracicCavityBand",  SqlDbType.Float,50, ChestData.thoracicCavityBand),
                                        data.MakeInParam("@UnderBustGirth",  SqlDbType.Float, 50, ChestData.underBustGirth),
                                        data.MakeInParam("@AcrossBack",  SqlDbType.Float, 50, ChestData.acrossBack),
                                        data.MakeInParam("@ChestThickness",  SqlDbType.Float, 50, ChestData.chestThickness),

            };
            return (data.RunProc("update ChestData set ID=@ID,AcrossFront=@AcrossFront,MilkInterval=@MilkInterval,NeckPointToBbustProminenceLeft=@NeckPointToBbustProminenceLeft,NeckPointToBustProminenceRight=@NeckPointToBustProminenceRight,Bust=@Bust,ThoracicCavityBand=@ThoracicCavityBand,UnderBustGirth=@UnderBustGirth,AcrossBack=@AcrossBack,ChestThickness=@ChestThickness where ID=@ID", prams));
        }
        #endregion

        #region 删除-胸部数据信息
        /// <summary>
        /// 删除胸部肩部数据
        /// </summary>
        /// <param name="ChestData"></param>
        /// <returns>返回胸部数据id</returns>
        public int DeleteChestData(cChestDataInfo ChestData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, ChestData.id),
            };
            return (data.RunProc("delete from ChestData where ID=@ID", prams));
        }
        #endregion

        //腹腰臀部数据查询修改添加删除
        #region 查询腹腰臀部数据信息
        /// <summary>
        /// 根据--编号--得到腹腰臀部数据信息
        /// </summary>
        /// <param name="BellyWaistHipData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindBellyWaistHipDataByID(cBellyWaistHipDataInfo BellyWaistHipData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, BellyWaistHipData.id+"%"),
            };
            return (data.RunProcReturn("select * from BellyWaistHipData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到腹腰臀部数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllBellyWaistHipData(string tbName)
        {
            return (data.RunProcReturn("select * from BellyWaistHipData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--腹腰臀部数据信息
        /// <summary>
        /// 添加--腹腰臀部数据--信息
        /// </summary>
        /// <param name="ChestData"></param>
        /// <returns></returns>
        public int AddBellyWaistHipData(cBellyWaistHipDataInfo BellyWaistHipData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, BellyWaistHipData.id),
                                        data.MakeInParam("@Waist",  SqlDbType.Float, 50,BellyWaistHipData.waist),
                                        data.MakeInParam("@WaistBackLevelDifference",  SqlDbType.Float,50, BellyWaistHipData.waistBackLevelDifference ),
                                        data.MakeInParam("@HipThickness",  SqlDbType.Float, 50, BellyWaistHipData.hipThickness ),
                                        data.MakeInParam("@AdominalThickness",  SqlDbType.Float, 50, BellyWaistHipData.adominalThickness),
                                        data.MakeInParam("@HipGirth",  SqlDbType.Float, 50, BellyWaistHipData.hipGirth),
                                        data.MakeInParam("@ButtockGirth",  SqlDbType.Float,50, BellyWaistHipData.buttockGirth ),
                                        data.MakeInParam("@MaximumHipGirth",  SqlDbType.Float, 50, BellyWaistHipData.maximumHipGirth),
                                        data.MakeInParam("@Belly",  SqlDbType.Float, 50, BellyWaistHipData.belly),
                                        data.MakeInParam("@MaximumBellyCircamference",  SqlDbType.Float, 50, BellyWaistHipData.maximumBellyCircamference),
                                        data.MakeInParam("@WaistPelvisDistance",  SqlDbType.Float, 50, BellyWaistHipData.waistPelvisDistance),
                                        data.MakeInParam("@WaistPelvisLengthLeft",  SqlDbType.Float,50, BellyWaistHipData.waistPelvisLengthLeft),
                                        data.MakeInParam("@WaistPelvisLengthRight",  SqlDbType.Float, 50, BellyWaistHipData.waistPelvisLengthRight),
                                        data.MakeInParam("@WaistUnderarmLeft",  SqlDbType.Float, 50, BellyWaistHipData.waistUnderarmLeft),
                                        data.MakeInParam("@WaistUnderarmRight",  SqlDbType.Float, 50, BellyWaistHipData.waistUnderarmRight),

            };
            return (data.RunProc("INSERT INTO BellyWaistHipData (ID,Waist,WaistBackLevelDifference,HipThickness,AdominalThickness,HipGirth,ButtockGirth,MaximumHipGirth,Belly,MaximumBellyCircamference,WaistPelvisDistance,WaistPelvisLengthLeft,WaistPelvisLengthRight,WaistUnderarmLeft,WaistUnderarmRight) VALUES (@ID,@Waist,@WaistBackLevelDifference,@HipThickness,@AdominalThickness,@HipGirth,@ButtockGirth,@MaximumHipGirth,@Belly,@MaximumBellyCircamference,@WaistPelvisDistance,@WaistPelvisLengthLeft,@WaistPelvisLengthRight,@WaistUnderarmLeft,@WaistUnderarmRight)", prams));
        }
        #endregion

        #region 修改--腹腰臀部数据信息
        /// <summary>
        /// 修改腹腰臀部数据信息
        /// </summary>
        /// <param name="BellyWaistHipData"></param>
        /// <returns></returns>
        public int UpdateBellyWaistHipData(cBellyWaistHipDataInfo BellyWaistHipData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, BellyWaistHipData.id),
                                        data.MakeInParam("@Waist",  SqlDbType.Float, 50,BellyWaistHipData.waist),
                                        data.MakeInParam("@WaistBackLevelDifference",  SqlDbType.Float,50, BellyWaistHipData.waistBackLevelDifference ),
                                        data.MakeInParam("@HipThickness",  SqlDbType.Float, 50, BellyWaistHipData.hipThickness ),
                                        data.MakeInParam("@AdominalThickness",  SqlDbType.Float, 50, BellyWaistHipData.adominalThickness),
                                        data.MakeInParam("@HipGirth",  SqlDbType.Float, 50, BellyWaistHipData.hipGirth),
                                        data.MakeInParam("@ButtockGirth",  SqlDbType.Float,50, BellyWaistHipData.buttockGirth ),
                                        data.MakeInParam("@MaximumHipGirth",  SqlDbType.Float, 50, BellyWaistHipData.maximumHipGirth),
                                        data.MakeInParam("@Belly",  SqlDbType.Float, 50, BellyWaistHipData.belly),
                                        data.MakeInParam("@MaximumBellyCircamference",  SqlDbType.Float, 50, BellyWaistHipData.maximumBellyCircamference),
                                        data.MakeInParam("@WaistPelvisDistance",  SqlDbType.Float, 50, BellyWaistHipData.waistPelvisDistance),
                                        data.MakeInParam("@WaistPelvisLengthLeft",  SqlDbType.Float,50, BellyWaistHipData.waistPelvisLengthLeft),
                                        data.MakeInParam("@WaistPelvisLengthRight",  SqlDbType.Float, 50, BellyWaistHipData.waistPelvisLengthRight),
                                        data.MakeInParam("@WaistUnderarmLeft",  SqlDbType.Float, 50, BellyWaistHipData.waistUnderarmLeft),
                                        data.MakeInParam("@WaistUnderarmRight",  SqlDbType.Float, 50, BellyWaistHipData.waistUnderarmRight),

            };
            return (data.RunProc("update BellyWaistHipData set ID=@ID,Waist=@Waist,WaistBackLevelDifference=@WaistBackLevelDifference,HipThickness=@HipThickness,AdominalThickness=@AdominalThickness,HipGirth=@HipGirth,ButtockGirth=@ButtockGirth,MaximumHipGirth=@MaximumHipGirth,Belly=@Belly,MaximumBellyCircamference=@MaximumBellyCircamference,WaistPelvisDistance=@WaistPelvisDistance,WaistPelvisLengthLeft=@WaistPelvisLengthLeft,WaistPelvisLengthRight=@WaistPelvisLengthRight,WaistUnderarmLeft=@WaistUnderarmLeft,WaistUnderarmRight=@WaistUnderarmRight where ID=@ID", prams));
        }
        #endregion

        #region 删除-腹腰臀部数据信息
        /// <summary>
        /// 删除腹腰臀部肩部数据
        /// </summary>
        /// <param name="BellyWaistHipData"></param>
        /// <returns>返回腹腰臀部数据id</returns>
        public int DeleteBellyWaistHipData(cBellyWaistHipDataInfo BellyWaistHipData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, BellyWaistHipData.id),
            };
            return (data.RunProc("delete from BellyWaistHipData where ID=@ID", prams));
        }
        #endregion

        //躯干数据查询修改添加删除
        #region 查询躯干数据信息
        /// <summary>
        /// 根据--编号--得到躯干数据信息
        /// </summary>
        /// <param name="TrunkIntegralData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindTrunkIntegralDataByID(cTrunkIntegralDataInfo TrunkIntegralData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, TrunkIntegralData.id+"%"),
            };
            return (data.RunProcReturn("select * from TrunkIntegralData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到躯干数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllTrunkIntegralData(string tbName)
        {
            return (data.RunProcReturn("select * from TrunkIntegralData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--躯干数据信息
        /// <summary>
        /// 添加--躯干数据--信息
        /// </summary>
        /// <param name="TrunkIntegralData"></param>
        /// <returns></returns>
        public int AddTrunkIntegralData(cTrunkIntegralDataInfo TrunkIntegralData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",SqlDbType.VarChar, 50, TrunkIntegralData.id),
                                        data.MakeInParam("@BodyHigh",SqlDbType.Float, 50,TrunkIntegralData.bodyHigh),
                                        data.MakeInParam("@CervicalHeight",SqlDbType.Float,50, TrunkIntegralData.cervicalHeight),
                                        data.MakeInParam("@CervicalHip",SqlDbType.Float, 50, TrunkIntegralData.cervicalHip),
                                        data.MakeInParam("@CervicalHeightKnee",SqlDbType.Float, 50, TrunkIntegralData.cervicalHeightKnee),
                                        data.MakeInParam("@CervicalWaist",SqlDbType.Float, 50, TrunkIntegralData.cervicalWaist),
                                        data.MakeInParam("@ScapulaHeight",SqlDbType.Float,50, TrunkIntegralData.scapulaHeight),
                                        data.MakeInParam("@BreastHeight",SqlDbType.Float, 50, TrunkIntegralData.breastHeight),
                                        data.MakeInParam("@NeckFrontHeight",SqlDbType.Float, 50, TrunkIntegralData.neckFrontHeight),


            };
            return (data.RunProc("INSERT INTO TrunkIntegralData (ID,BodyHigh,CervicalHeight,CervicalHip,CervicalHeightKnee,CervicalWaist,ScapulaHeight,BreastHeight,NeckFrontHeight) VALUES (@ID,@BodyHigh,@CervicalHeight,@CervicalHip,@CervicalHeightKnee,@CervicalWaist,@ScapulaHeight,@BreastHeight,@NeckFrontHeight)", prams));
        }
        #endregion

        #region 修改--躯干数据信息
        /// <summary>
        /// 修改躯干数据信息
        /// </summary>
        /// <param name="TrunkIntegralData"></param>
        /// <returns></returns>
        public int UpdateTrunkIntegralData(cTrunkIntegralDataInfo TrunkIntegralData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, TrunkIntegralData.id),
                                        data.MakeInParam("@BodyHigh",  SqlDbType.Float, 50,TrunkIntegralData.bodyHigh),
                                        data.MakeInParam("@CervicalHeight",  SqlDbType.Float,50, TrunkIntegralData.cervicalHeight),
                                        data.MakeInParam("@CervicalHip",  SqlDbType.Float, 50, TrunkIntegralData.cervicalHip),
                                        data.MakeInParam("@CervicalHeightKnee",  SqlDbType.Float, 50, TrunkIntegralData.cervicalHeightKnee),
                                        data.MakeInParam("@CervicalWaist",  SqlDbType.Float, 50, TrunkIntegralData.cervicalWaist),
                                        data.MakeInParam("@ScapulaHeight",  SqlDbType.Float,50, TrunkIntegralData.scapulaHeight),
                                        data.MakeInParam("@BreastHeight",  SqlDbType.Float, 50, TrunkIntegralData.breastHeight),
                                        data.MakeInParam("@NeckFrontHeight",  SqlDbType.Float, 50, TrunkIntegralData.neckFrontHeight),


            };
            return (data.RunProc("update TrunkIntegralData set ID=@ID,BodyHigh=@BodyHigh,CervicalHeight=@CervicalHeight,CervicalHip=@CervicalHip,CervicalHeightKnee=@CervicalHeightKnee,CervicalWaist=@CervicalWaist,ScapulaHeight=@ScapulaHeight,BreastHeight=@BreastHeight,NeckFrontHeight=@NeckFrontHeight where ID=@ID", prams));
        }
        #endregion

        #region 删除-躯干数据信息
        /// <summary>
        /// 删除躯干数据
        /// </summary>
        /// <param name="TrunkIntegralData"></param>
        /// <returns>返回躯干数据id</returns>
        public int DeleteTrunkIntegralData(cTrunkIntegralDataInfo TrunkIntegralData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, TrunkIntegralData.id),
            };
            return (data.RunProc("delete from TrunkIntegralData where ID=@ID", prams));
        }
        #endregion

        //上肢数据查询修改添加删除
        #region 查询上肢数据信息
        /// <summary>
        /// 根据--编号--得到躯干数据信息
        /// </summary>
        /// <param name="UpperLimbsData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUpperLimbsDataByID(cUpperLimbsDataInfo UpperLimbsData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, UpperLimbsData.id+"%"),
            };
            return (data.RunProcReturn("select * from UpperLimbsData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到上肢数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUpperLimbsData(string tbName)
        {
            return (data.RunProcReturn("select * from UpperLimbsData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--上肢数据信息
        /// <summary>
        /// 添加--上肢数据--信息
        /// </summary>
        /// <param name="UpperLimbsData"></param>
        /// <returns></returns>
        public int AddUpperLimbsData(cUpperLimbsDataInfo UpperLimbsData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, UpperLimbsData.id),
                                        data.MakeInParam("@CervicalWristLengthLeft",  SqlDbType.Float, 50,UpperLimbsData.cervicalWristLengthLeft),
                                        data.MakeInParam("@CervicalWristLengthRight",  SqlDbType.Float,50, UpperLimbsData.cervicalWristLengthRight),
                                        data.MakeInParam("@ArmLengthLeft",  SqlDbType.Float, 50, UpperLimbsData.armLengthLeft),
                                        data.MakeInParam("@ArmLengthRight",  SqlDbType.Float, 50, UpperLimbsData.armLengthRight),
                                        data.MakeInParam("@UpperArmLengthLeft ",  SqlDbType.Float, 50, UpperLimbsData.upperArmLengthLeft),
                                        data.MakeInParam("@UpperArmLengthRight",  SqlDbType.Float,50, UpperLimbsData.upperArmLengthRight),
                                        data.MakeInParam("@UpperArmGirthLeft",  SqlDbType.Float, 50, UpperLimbsData.upperArmGirthLeft),
                                        data.MakeInParam("@UpperArmGirthRight",  SqlDbType.Float, 50, UpperLimbsData.upperArmGirthRight),
                                        data.MakeInParam("@WristGirthLeft",  SqlDbType.Float, 50, UpperLimbsData.wristGirthLeft),
                                        data.MakeInParam("@WristGirthRight",  SqlDbType.Float,50, UpperLimbsData.wristGirthRight),
                                        data.MakeInParam("@HandThickness",  SqlDbType.Float, 50, UpperLimbsData.handThickness),
                                        data.MakeInParam("@HandGirth",  SqlDbType.Float, 50, UpperLimbsData.handGirth),


            };
            return (data.RunProc("INSERT INTO UpperLimbsData (ID,CervicalWristLengthLeft,CervicalWristLengthRight,ArmLengthLeft,ArmLengthRight,UpperArmLengthLeft,UpperArmLengthRight,UpperArmGirthLeft,UpperArmGirthRight,WristGirthLeft,WristGirthRight,HandThickness,HandGirth) VALUES (@ID,@CervicalWristLengthLeft,@CervicalWristLengthRight,@ArmLengthLeft,@ArmLengthRight,@UpperArmLengthLeft,@UpperArmLengthRight,@UpperArmGirthLeft,@UpperArmGirthRight,@WristGirthLeft,@WristGirthRight,@HandThickness,@HandGirth)", prams));
        }
        #endregion

        #region 修改--上肢数据信息
        /// <summary>
        /// 修改上肢数据信息
        /// </summary>
        /// <param name="UpperLimbsData"></param>
        /// <returns></returns>
        public int UpdateUpperLimbsData(cUpperLimbsDataInfo UpperLimbsData)
        {
            SqlParameter[] prams = {
                                       data.MakeInParam("@ID",  SqlDbType.VarChar, 50, UpperLimbsData.id),
                                        data.MakeInParam("@CervicalWristLengthLeft",  SqlDbType.Float, 50,UpperLimbsData.cervicalWristLengthLeft),
                                        data.MakeInParam("@CervicalWristLengthRight",  SqlDbType.Float,50, UpperLimbsData.cervicalWristLengthRight),
                                        data.MakeInParam("@ArmLengthLeft",  SqlDbType.Float, 50, UpperLimbsData.armLengthLeft),
                                        data.MakeInParam("@ArmLengthRight",  SqlDbType.Float, 50, UpperLimbsData.armLengthRight),
                                        data.MakeInParam("@UpperArmLengthLeft ",  SqlDbType.Float, 50, UpperLimbsData.upperArmLengthLeft),
                                        data.MakeInParam("@UpperArmLengthRight",  SqlDbType.Float,50, UpperLimbsData.upperArmLengthRight),
                                        data.MakeInParam("@UpperArmGirthLeft",  SqlDbType.Float, 50, UpperLimbsData.upperArmGirthLeft),
                                        data.MakeInParam("@UpperArmGirthRight",  SqlDbType.Float, 50, UpperLimbsData.upperArmGirthRight),
                                        data.MakeInParam("@WristGirthLeft",  SqlDbType.Float, 50, UpperLimbsData.wristGirthLeft),
                                        data.MakeInParam("@WristGirthRight",  SqlDbType.Float,50, UpperLimbsData.wristGirthRight),
                                        data.MakeInParam("@HandThickness",  SqlDbType.Float, 50, UpperLimbsData.handThickness),
                                        data.MakeInParam("@HandGirth",  SqlDbType.Float, 50, UpperLimbsData.handGirth),


            };
            return (data.RunProc("update UpperLimbsData set ID=@ID,CervicalWristLengthLeft=@CervicalWristLengthLeft,CervicalWristLengthRight=@CervicalWristLengthRight,ArmLengthLeft=@ArmLengthLeft,ArmLengthRight=@ArmLengthRight,UpperArmLengthLeft=@UpperArmLengthLeft,UpperArmLengthRight=@UpperArmLengthRight,UpperArmGirthLeft=@UpperArmGirthLeft,UpperArmGirthRight=@UpperArmGirthRight,WristGirthLeft=@WristGirthLeft,WristGirthRight=@WristGirthRight,HandThickness=@HandThickness,HandGirth=@HandGirth where ID=@ID", prams));
        }
        #endregion

        #region 删除-上肢数据信息
        /// <summary>
        /// 删除上肢数据
        /// </summary>
        /// <param name="UpperLimbsData"></param>
        /// <returns>返回上肢数据id</returns>
        public int DeleteUpperLimbsData(cUpperLimbsDataInfo UpperLimbsData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, UpperLimbsData.id),
            };
            return (data.RunProc("delete from UpperLimbsData where ID=@ID", prams));
        }
        #endregion

        //下肢数据查询修改添加删除
        #region 查询下肢数据信息
        /// <summary>
        /// 根据--编号--得到下肢数据信息
        /// </summary>
        /// <param name="LowerLimbsData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindLowerLimbsDataByID(cLowerLimbsDataInfo LowerLimbsData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, LowerLimbsData.id+"%"),
            };
            return (data.RunProcReturn("select * from LowerLimbsData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到下肢数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllLowerLimbsData(string tbName)
        {
            return (data.RunProcReturn("select * from LowerLimbsData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--下肢数据信息
        /// <summary>
        /// 添加--下肢数据--信息
        /// </summary>
        /// <param name="LowerLimbsData"></param>
        /// <returns></returns>
        public int AddLowerLimbsData(cLowerLimbsDataInfo LowerLimbsData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, LowerLimbsData.id),
                                        data.MakeInParam("@InsideLegLengthLeft",  SqlDbType.Float, 50,LowerLimbsData.insideLegLengthLeft),
                                        data.MakeInParam("@InsideLegLengthRight",  SqlDbType.Float,50, LowerLimbsData.insideLegLengthRight ),
                                        data.MakeInParam("@SideLengthToWaistLeft",  SqlDbType.Float, 50, LowerLimbsData.sideLengthToWaistLeft),
                                        data.MakeInParam("@SideLengthToWaistRight",  SqlDbType.Float, 50, LowerLimbsData.sideLengthToWaistRight ),
                                        data.MakeInParam("@LateralHeightOfWaistLeft ",  SqlDbType.Float, 50, LowerLimbsData.lateralHeightOfWaistLeft),
                                        data.MakeInParam("@LateralHeightOfWaistRight",  SqlDbType.Float,50, LowerLimbsData.lateralHeightOfWaistRight),
                                        data.MakeInParam("@ThighGirthLeft",  SqlDbType.Float, 50, LowerLimbsData.thighGirthLeft),
                                        data.MakeInParam("@ThighGirthRight",  SqlDbType.Float, 50, LowerLimbsData.thighGirthRight),
                                        data.MakeInParam("@KneeGirthLeft",  SqlDbType.Float, 50, LowerLimbsData.kneeGirthLeft),
                                        data.MakeInParam("@KneeGirthRight",  SqlDbType.Float,50, LowerLimbsData.kneeGirthRight),
                                        data.MakeInParam("@CalfGirthLeft",  SqlDbType.Float, 50, LowerLimbsData.calfGirthLeft),
                                        data.MakeInParam("@CalfGirthRight",  SqlDbType.Float, 50, LowerLimbsData.calfGirthRight),
                                        data.MakeInParam("@AnkleGirthLeft",  SqlDbType.Float,50, LowerLimbsData.ankleGirthLeft),
                                        data.MakeInParam("@AnkleGirthRight",  SqlDbType.Float, 50, LowerLimbsData.ankleGirthRight),
                                        data.MakeInParam("@WaistKnee",  SqlDbType.Float, 50, LowerLimbsData.waistKnee),
                                        data.MakeInParam("@WaistHeight",  SqlDbType.Float, 50, LowerLimbsData.waistHeight),
                                        data.MakeInParam("@HipHeight",  SqlDbType.Float,50, LowerLimbsData.hipHeight),
                                        data.MakeInParam("@MaximumHipHeight",  SqlDbType.Float, 50, LowerLimbsData.maximumHipHeight),
                                        data.MakeInParam("@CrothHeight",  SqlDbType.Float, 50, LowerLimbsData.crothHeight),
                                        data.MakeInParam("@BellyHeight",  SqlDbType.Float, 50, LowerLimbsData.bellyHeight),
                                        data.MakeInParam("@MaximuBellyHeight",  SqlDbType.Float,50, LowerLimbsData.maximuBellyHeight),
                                        data.MakeInParam("@CrothToWaistband",  SqlDbType.Float, 50, LowerLimbsData.crothToWaistband),
                                        data.MakeInParam("@CrothLength",  SqlDbType.Float, 50, LowerLimbsData.crothLength),


            };
            return (data.RunProc("INSERT INTO LowerLimbsData (ID,InsideLegLengthLeft,InsideLegLengthRight,SideLengthToWaistLeft,SideLengthToWaistRight,LateralHeightOfWaistLeft,LateralHeightOfWaistRight,ThighGirthLeft,ThighGirthRight,KneeGirthLeft,KneeGirthRight,CalfGirthLeft,CalfGirthRight,AnkleGirthLeft,AnkleGirthRight,WaistKnee,WaistHeight,HipHeight,MaximumHipHeight,CrothHeight,BellyHeight,MaximuBellyHeight,CrothToWaistband,CrothLength) VALUES (@ID,@InsideLegLengthLeft,@InsideLegLengthRight,@SideLengthToWaistLeft,@SideLengthToWaistRight,@LateralHeightOfWaistLeft,@LateralHeightOfWaistRight,@ThighGirthLeft,@ThighGirthRight,@KneeGirthLeft,@KneeGirthRight,@CalfGirthLeft,@CalfGirthRight,@AnkleGirthLeft,@AnkleGirthRight,@WaistKnee,@WaistHeight,@HipHeight,@MaximumHipHeight,@CrothHeight,@BellyHeight,@MaximuBellyHeight,@CrothToWaistband,@CrothLength)", prams));
        }
        #endregion

        #region 修改--下肢数据信息
        /// <summary>
        /// 修改下肢数据信息
        /// </summary>
        /// <param name="LowerLimbsData"></param>
        /// <returns></returns>
        public int UpdateLowerLimbsData(cLowerLimbsDataInfo LowerLimbsData)
        {
            SqlParameter[] prams = {
                                  data.MakeInParam("@ID",  SqlDbType.VarChar, 50, LowerLimbsData.id),
                                        data.MakeInParam("@InsideLegLengthLeft",  SqlDbType.Float, 50,LowerLimbsData.insideLegLengthLeft),
                                        data.MakeInParam("@InsideLegLengthRight",  SqlDbType.Float,50, LowerLimbsData.insideLegLengthRight ),
                                        data.MakeInParam("@SideLengthToWaistLeft",  SqlDbType.Float, 50, LowerLimbsData.sideLengthToWaistLeft),
                                        data.MakeInParam("@SideLengthToWaistRight",  SqlDbType.Float, 50, LowerLimbsData.sideLengthToWaistRight ),
                                        data.MakeInParam("@LateralHeightOfWaistLeft ",  SqlDbType.Float, 50, LowerLimbsData.lateralHeightOfWaistLeft),
                                        data.MakeInParam("@LateralHeightOfWaistRight",  SqlDbType.Float,50, LowerLimbsData.lateralHeightOfWaistRight),
                                        data.MakeInParam("@ThighGirthLeft",  SqlDbType.Float, 50, LowerLimbsData.thighGirthLeft),
                                        data.MakeInParam("@ThighGirthRight",  SqlDbType.Float, 50, LowerLimbsData.thighGirthRight),
                                        data.MakeInParam("@KneeGirthLeft",  SqlDbType.Float, 50, LowerLimbsData.kneeGirthLeft),
                                        data.MakeInParam("@KneeGirthRight",  SqlDbType.Float,50, LowerLimbsData.kneeGirthRight),
                                        data.MakeInParam("@CalfGirthLeft",  SqlDbType.Float, 50, LowerLimbsData.calfGirthLeft),
                                        data.MakeInParam("@CalfGirthRight",  SqlDbType.Float, 50, LowerLimbsData.calfGirthRight),
                                        data.MakeInParam("@AnkleGirthLeft",  SqlDbType.Float,50, LowerLimbsData.ankleGirthLeft),
                                        data.MakeInParam("@AnkleGirthRight",  SqlDbType.Float, 50, LowerLimbsData.ankleGirthRight),
                                        data.MakeInParam("@WaistKnee",  SqlDbType.Float, 50, LowerLimbsData.waistKnee),
                                        data.MakeInParam("@WaistHeight",  SqlDbType.Float, 50, LowerLimbsData.waistHeight),
                                        data.MakeInParam("@HipHeight",  SqlDbType.Float,50, LowerLimbsData.hipHeight),
                                        data.MakeInParam("@MaximumHipHeight",  SqlDbType.Float, 50, LowerLimbsData.maximumHipHeight),
                                        data.MakeInParam("@CrothHeight",  SqlDbType.Float, 50, LowerLimbsData.crothHeight),
                                        data.MakeInParam("@BellyHeight",  SqlDbType.Float, 50, LowerLimbsData.bellyHeight),
                                        data.MakeInParam("@MaximuBellyHeight",  SqlDbType.Float,50, LowerLimbsData.maximuBellyHeight),
                                        data.MakeInParam("@CrothToWaistband",  SqlDbType.Float, 50, LowerLimbsData.crothToWaistband),
                                        data.MakeInParam("@CrothLength",  SqlDbType.Float, 50, LowerLimbsData.crothLength),

            };
            return (data.RunProc("update LowerLimbsData set ID=@ID,InsideLegLengthLeft=@InsideLegLengthLeft,InsideLegLengthRight=@InsideLegLengthRight,SideLengthToWaistLeft=@SideLengthToWaistLeft,SideLengthToWaistRight=@SideLengthToWaistRight,LateralHeightOfWaistLeft=@LateralHeightOfWaistLeft,LateralHeightOfWaistRight=@LateralHeightOfWaistRight,ThighGirthLeft=@ThighGirthLeft,ThighGirthRight=@ThighGirthRight,KneeGirthLeft=@KneeGirthLeft,KneeGirthRight=@KneeGirthRight,CalfGirthLeft=@CalfGirthLeft,CalfGirthRight=@CalfGirthRight,AnkleGirthLeft=@AnkleGirthLeft,AnkleGirthRight=@AnkleGirthRight,WaistKnee=@WaistKnee,WaistHeight=@WaistHeight,HipHeight=@HipHeight,MaximumHipHeight=@MaximumHipHeight,CrothHeight=@CrothHeight,BellyHeight=@BellyHeight,MaximuBellyHeight=@MaximuBellyHeight,CrothToWaistband=@CrothToWaistband,CrothLength=@CrothLength where ID=@ID", prams));
        }
        #endregion

        #region 删除-下肢数据信息
        /// <summary>
        /// 删除下肢数据
        /// </summary>
        /// <param name="LowerLimbsData"></param>
        /// <returns>返回下肢数据id</returns>
        public int DeleteLowerLimbsData(cLowerLimbsDataInfo LowerLimbsData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, LowerLimbsData.id),
            };
            return (data.RunProc("delete from LowerLimbsData where ID=@ID", prams));
        }
        #endregion

        ///足部数据查询修改添加删除
        #region 查询足部数据信息
        /// <summary>
        /// 根据--编号--得到足部数据信息
        /// </summary>
        /// <param name="FootData"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindFootDataByID(cFootDataInfo FootData, string tbName)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, FootData.id+"%"),
            };
            return (data.RunProcReturn("select * from FootData where ID like @ID", prams, tbName));
        }

        /// <summary>
        /// 得到足部数据信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllFootData(string tbName)
        {
            return (data.RunProcReturn("select * from FootData ORDER BY ID", tbName));
        }
        #endregion

        #region 添加--足部数据信息
        /// <summary>
        /// 添加--足部数据--信息
        /// </summary>
        /// <param name="FootData"></param>
        /// <returns></returns>
        public int AddFootData(cFootDataInfo FootData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, FootData.id),
                                        data.MakeInParam("@FootLength",  SqlDbType.Float, 50,FootData.footLength),
                                        data.MakeInParam("@FootWidth",  SqlDbType.Float,50, FootData.footWidth),
                                        data.MakeInParam("@FootGirth",  SqlDbType.Float, 50, FootData.footGirth),
                                        data.MakeInParam("@ToeHeihet",  SqlDbType.Float, 50, FootData.toeHeihet),
                                        data.MakeInParam("@FootTarsiHigh",  SqlDbType.Float, 50, FootData.footTarsiHigh),
                                        data.MakeInParam("@MedialMalleolusHigh",  SqlDbType.Float,50, FootData.medialMalleolusHigh),
                                        data.MakeInParam("@LateralMalleolusHigh",  SqlDbType.Float, 50, FootData.lateralMalleolusHigh),

            };
            return (data.RunProc("INSERT INTO FootData (ID,FootLength,FootWidth,FootGirth,ToeHeihet,FootTarsiHigh,MedialMalleolusHigh,LateralMalleolusHigh) VALUES (@ID,@FootLength,@FootWidth,@FootGirth,@ToeHeihet,@FootTarsiHigh,@MedialMalleolusHigh,@LateralMalleolusHigh)", prams));
        }
        #endregion

        #region 修改--足部数据信息
        /// <summary>
        /// 修改足部数据信息
        /// </summary>
        /// <param name="FootData"></param>
        /// <returns></returns>
        public int UpdateFootData(cFootDataInfo FootData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, FootData.id),
                                        data.MakeInParam("@FootLength",  SqlDbType.Float, 50,FootData.footLength),
                                        data.MakeInParam("@FootWidth",  SqlDbType.Float,50, FootData.footWidth),
                                        data.MakeInParam("@FootGirth",  SqlDbType.Float, 50, FootData.footGirth),
                                        data.MakeInParam("@ToeHeihet",  SqlDbType.Float, 50, FootData.toeHeihet),
                                        data.MakeInParam("@FootTarsiHigh",  SqlDbType.Float, 50, FootData.footTarsiHigh),
                                        data.MakeInParam("@MedialMalleolusHigh",  SqlDbType.Float,50, FootData.medialMalleolusHigh),
                                        data.MakeInParam("@LateralMalleolusHigh",  SqlDbType.Float, 50, FootData.lateralMalleolusHigh),


            };
            return (data.RunProc("update FootData set ID=@ID,FootLength=@FootLength,FootWidth=@FootWidth,FootGirth=@FootGirth,ToeHeihet=@ToeHeihet,FootTarsiHigh=@FootTarsiHigh,MedialMalleolusHigh=@MedialMalleolusHigh,LateralMalleolusHigh=@LateralMalleolusHigh where ID=@ID", prams));
        }
        #endregion

        #region 删除-足部数据信息
        /// <summary>
        /// 删除足部数据
        /// </summary>
        /// <param name="FootData"></param>
        /// <returns>返回足部数据id</returns>
        public int DeleteFootData(cFootDataInfo FootData)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@ID",  SqlDbType.VarChar, 50, FootData.id),
            };
            return (data.RunProc("delete from [FootData] where ID=@ID", prams));
        }
        #endregion

        #region  数据库备份与恢复--系统管理
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="bakUpName"></param>
        public void BackUp(string bakUpName)
        {
            data.RunProc("BACKUP DATABASE db_BID TO DISK ='" + bakUpName + "'");
        }
        /// <summary>
        /// 恢复数据库
        /// </summary>
        /// <param name="reStoreName"></param>
        public void ReStore(string reStoreName)
        {
            data.RunProc("backup log db_BID to disk='" + reStoreName + "'use master RESTORE DATABASE db_BID from disk='" + reStoreName + "'");
        }
        #endregion

        #region  系统数据清理--系统管理
        /// <summary>
        /// 根据指定的数据表清除数据表中数据
        /// </summary>
        /// <param name="tbName_true"></param>
        public void ClearTable(string tbName_true)
        {
            data.RunProc("delete from " + tbName_true + "");
        }
        #endregion

        #region 系统操作员及权限设置--系统管理
        /// <summary>
        /// 添加系统操作员
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        public void AddSysUser(string userName, string pwd)
        {
            data.RunProc("INSERT INTO [User] (sysuser, password) VALUES ('" + userName + "', '" + pwd + "')");
        }
        /// <summary>
        /// 删除系统操作员
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteSysUser(int ID)
        {
            data.RunProc("delete from [User] where id='" + ID + "'");
        }
        /// <summary>
        /// 获得所有系统用户信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllUser()
        {
            return (data.RunProcReturn("select * from [User]", "User"));
        }
        /// <summary>
        /// 根据用户名称---查询系统用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool FindUserName(string userName)
        {
            DataSet ds = null;
            ds = data.RunProcReturn("select * from [User] where [sysuser]='" + userName + "'", "User");
            if (ds.Tables[0].Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 修改系统用户信息及所对应的权限
        /// </summary>
        /// <param name="popedom"></param>
        public void UpdateSysUser(cPopedom popedom)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@id",  SqlDbType.Int, 4, popedom.ID),
                                        data.MakeInParam("@sysuser",  SqlDbType.VarChar, 20, popedom.SysUser),
                                        data.MakeInParam("@password",  SqlDbType.VarChar, 20,popedom.Password),
                                        data.MakeInParam("@system",  SqlDbType.Bit, 1, popedom.SystemSet),
                                        data.MakeInParam("@base",  SqlDbType.Bit, 1, popedom.Base_Info),
                                        data.MakeInParam("@analyze",  SqlDbType.Bit, 1, popedom.Analyze),
                                        data.MakeInParam("@classify",  SqlDbType.Bit, 1, popedom.Classify),
                                        data.MakeInParam("@discern",  SqlDbType.Bit, 1, popedom.Discern),
            };
            int i = data.RunProc("update [User] set sysuser=@sysuser,password=@password,system=@system,base=@base,analyze=@analyze ,classify=@classify,discern=@discern where id=@id", prams);
        }
        #endregion

        #region 辅助工具管理
        //ShellExecute Me.hWnd, "open", "http://www.mingrisoft.com", 1, 1, 5
        public void OpenInernet()
        {

        }
        #endregion

        #region  设置文本框只能输入数字型字符串
        /// <summary>
        /// 文本框只能输入数字型和单精度型的字符串.
        /// </summary>
        /// <param name="e">KeyPressEventArgs类</param>
        /// <param name="s">文本框的字符串</param>
        /// <param name="n">标识，判断是数字型还是单精度型</param>
        public void Estimate_Key(KeyPressEventArgs e, string s, int n)
        {
            if (n == 0)   //只能输入整型
                if (!(e.KeyChar <= '9' && e.KeyChar >= '0') && e.KeyChar != '\r' && e.KeyChar != '\b')
                {
                    e.Handled = true;   //处理KeyPress事件
                }
            if (n == 1) //可以输入整型或单精度型
            {
                if ((!(e.KeyChar <= '9' && e.KeyChar >= '0')) && e.KeyChar != '.' && e.KeyChar != '\r' && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.KeyChar == '.')   //如果输入“.”
                        if (s == "")    //当前文本框为空
                            e.Handled = true;   //处理KeyPress事件
                        else
                        {
                            if (s.Length > 0)   //当文本框不为空时
                            {
                                if (s.IndexOf(".") > -1)    //查找是否已输入过“.”
                                    e.Handled = true;   //处理KeyPress事件
                            }
                        }
                }
            }
        }
        #endregion 

        #region  遍历清空指定的控件
        /// <summary>
        /// 清空所有控件下的所有控件.
        /// </summary>
        /// <param name="Con">可视化控件</param>
        public void Clear_Control(Control.ControlCollection Con)
        {
            foreach (Control C in Con)
            { //遍历可视化组件中的所有控件
                if (C.GetType().Name == "TextBox")  //判断是否为TextBox控件
                    if (((TextBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((TextBox)C).Clear();   //清空当前控件
              
                if (C.GetType().Name == "ComboBox")  //判断是否为ComboBox控件
                    if (((ComboBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((ComboBox)C).Text = "";   //清空当前控件的Text属性值
            }
        }
        #endregion 

        #region  将当前表的数据信息显示在指定的控件上
        /// <summary>
        /// 将DataGridView控件的当前记录显示在其它控件上.
        /// </summary>
        /// <param name="DGrid">DataGridView控件</param>
        /// <param name="GBox">GroupBox控件的数据集</param>
        /// <param name="TName">获取信息控件的部份名称</param>
        public void Show_DGrid(DataGridView DGrid, Control.ControlCollection GBox, string TName)
        {
            string sID = "";
            if (DGrid.RowCount > 0)
            {
                for (int i = 2; i < DGrid.ColumnCount; i++)
                {
                    sID = TName + i.ToString();
                    foreach (Control C in GBox)
                    {
                        if (C.GetType().Name == "TextBox"  | C.GetType().Name == "ComboBox")
                            if (C.Name == sID)
                            {
                                if (C.GetType().Name != "MaskedTextBox")
                                    C.Text = DGrid[i, DGrid.CurrentCell.RowIndex].Value.ToString();
                            }
                    }
                }
            }

        }
        #endregion

        #region 系统登录
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="popedom"></param>
        /// <returns></returns>
        public DataSet Login(cPopedom popedom)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@sysuser",  SqlDbType.VarChar, 20, popedom.SysUser),
                                        data.MakeInParam("@password",  SqlDbType.VarChar, 20,popedom.Password),
            };
            return (data.RunProcReturn("SELECT * FROM [User] WHERE (sysuser = @sysuser) AND (password = @password)", prams, "User"));
        }
        #endregion
    }

      

        #region 定义基础数据--数据结构
        public class cBasicDataInfo
        {
            private string ID = "";
            private string Age = "";
            private string Sex = "";
            private string BodyHigh = "";
            private string IDCard = "";
            private string Waist = "";
            private string Bust = "";
            private string ButtockGirth = "";
        /// <summary>
        /// 编号
        /// </summary>
        public string id
            {
                get { return ID; }
                set { ID = value; }
            }
            /// <summary>
            /// 年龄
            /// </summary>
            public string age
            {
                get { return Age; }
                set { Age = value; }
            }
            /// <summary>
            /// 性别
            /// </summary>
            public string sex
            {
                get { return Sex; }
                set { Sex = value; }
            }
            /// <summary>
            /// 身高
            /// </summary>
            public string bodyhigh
            {
                get { return BodyHigh; }
                set { BodyHigh = value; }
            }
            /// <summary>
            ///身份证前六位
            /// </summary>
            public string idcard
            {
                get { return IDCard; }
                set { IDCard = value; }
            }
        /// <summary>
        /// 胸围
        /// </summary>
        public string bust
        {
            get { return Bust; }
            set { Bust = value; }
        }
        /// <summary>
        /// 腰围
        /// </summary>
        public string waist
        {
            get { return Waist; }
            set { Waist = value; }
        }
        /// <summary>
        ///臀围
        /// </summary>
        public string buttockGirth
        {
            get { return ButtockGirth; }
            set { ButtockGirth = value; }
        }
    }

    #endregion

        #region 定义Owner数据--数据结构
    public class cOwnerInfo
    {
        private string ID = "";
        private string Sex = "";
        private string Age = "";
        private string Job = "";
        private string WorkUnit = "";
        private string IDCard = "";
        private string Weight = "";

        /// <summary>
        /// 编号
        /// </summary>
        public string id
        {
            get { return ID; }
            set { ID = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string age
        {
            get { return Age; }
            set { Age = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string sex
        {
            get { return Sex; }
            set { Sex = value; }
        }
        /// <summary>
        ///身份证前六位
        /// </summary>
        public string idcard
        {
            get { return IDCard; }
            set { IDCard = value; }
        }
        /// <summary>
        ///职位
        /// </summary>
        public string job
        {
            get { return Job; }
            set { Job = value; }
        }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string workUnit
        {
            get { return WorkUnit; }
            set { WorkUnit = value; }
        }
        /// <summary>
        ///体重
        /// </summary>
        public string weight
        {
            get { return Weight; }
            set { Weight = value; }
        }
    }

    #endregion

        #region 定义头部数据--数据结构
    public class cHeaderDataInfo
        {
            private string ID = "";
            private string HeadHeight = "";
            private string HeadWidth = "";
            private string HeadLength = "";
            private string HeadGirth = "";
            private string CrownShapeAround = "";
            private string BitragionIntertragicArc = "";
            private string HeadSagittalArc = "";
            private string BrowTopNeckArcLength = "";
            private string MorphoGicalFacialLength = "";
            private string InterpupillaryDistance = "";
            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }
            /// <summary>
            /// 头高
            /// </summary>
            public string headHeight
            {
                get { return HeadHeight; }
                set { HeadHeight = value; }
            }
            /// <summary>
            /// 头宽
            /// </summary>
            public string headWidth
            {
                get { return HeadWidth; }
                set { HeadWidth = value; }
            }
            /// <summary>
            /// 头长
            /// </summary>
            public string headLength
            {
                get { return HeadLength; }
                set { HeadLength = value; }
            }
            /// <summary>
            /// 头围
            /// </summary>
            public string headGirth
            {
                get { return HeadGirth; }
                set { HeadGirth = value; }
            }
            /// <summary>
            ///头冠状围
            /// </summary>
            public string crownShapeAround
            {
                get { return CrownShapeAround; }
                set { CrownShapeAround = value; }
            }
            /// <summary>
            /// 耳屏间弧
            /// </summary>
            public string bitragionIntertragicArc
            {
                get { return BitragionIntertragicArc; }
                set { BitragionIntertragicArc = value; }
            }
            /// <summary>
            /// 头矢状弧
            /// </summary>
            public string headSagittalArc
            {
                get { return HeadSagittalArc; }
                set { HeadSagittalArc = value; }
            }
            /// <summary>
            /// 眉间顶颈弧长
            /// </summary>
            public string browTopNeckArcLength
            {
                get { return BrowTopNeckArcLength; }
                set { BrowTopNeckArcLength = value; }
            }
            /// <summary>
            /// 形态面长
            /// </summary>
            public string morphoGicalFacialLength
            {
                get { return MorphoGicalFacialLength; }
                set { MorphoGicalFacialLength = value; }
            }
            /// <summary>
            ///瞳孔间距
            /// </summary>
            public string interpupillaryDistance
            {
                get { return InterpupillaryDistance; }
                set { InterpupillaryDistance = value; }
            }
        }

        #endregion

        #region 定义颈部数据--数据结构
        public class cNeckDataInfo
        {
            private string ID = "";
            private string CervixThickness = "";
            private string MidNeckGirth = "";
            private string NeckGirth = "";

            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }

            /// <summary>
            /// 颈中厚
            /// </summary>
            public string cervixThickness
            {
                get { return CervixThickness; }
                set { CervixThickness = value; }
            }
            /// <summary>
            /// 颈中围
            /// </summary>
            public string midNeckGirth
            {
                get { return MidNeckGirth; }
                set { MidNeckGirth = value; }
            }
            /// <summary>
            /// 颈围
            /// </summary>
            public string neckGirth
            {
                get { return NeckGirth; }
                set { NeckGirth = value; }
            }
        }

        #endregion

        #region 定义肩部数据--数据结构
        public class cShoulderDataInfo
        {
            private string ID = "";
            private string ShoulderAcross = "";
            private string LeftShoulder = "";
            private string RightShoulder = "";
            private string LeftShoulderAngle = "";
            private string RightShoulderAngle = "";

            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }

            /// <summary>
            /// 肩宽
            /// </summary>
            public string shoulderAcross
            {
                get { return ShoulderAcross; }
                set { ShoulderAcross = value; }
            }
            /// <summary>
            /// 左肩宽
            /// </summary>
            public string leftShoulder
            {
                get { return LeftShoulder; }
                set { LeftShoulder = value; }
            }
            /// <summary>
            /// 右肩宽
            /// </summary>
            public string rightShoulder
            {
                get { return RightShoulder; }
                set { RightShoulder = value; }
            }
            /// <summary>
            /// 左肩斜
            /// </summary>
            public string leftShoulderAngle
            {
                get { return LeftShoulderAngle; }
                set { LeftShoulderAngle = value; }
            }
            /// <summary>
            /// 右肩斜
            /// </summary>
            public string rightShoulderAngle
            {
                get { return RightShoulderAngle; }
                set { RightShoulderAngle = value; }
            }
        }

        #endregion

        #region 定义胸数据--数据结构
        public class cChestDataInfo
        {
            private string ID = "";
            private string AcrossFront = "";
            private string MilkInterval = "";
            private string NeckPointToBbustProminenceLeft = "";
            private string NeckPointToBustProminenceRight = "";
            private string Bust = "";
            private string ThoracicCavityBand = "";
            private string UnderBustGirth = "";
            private string AcrossBack = "";
            private string ChestThickness = "";

            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }
            /// <summary>
            /// 前胸宽
            /// </summary>
            public string acrossFront
            {
                get { return AcrossFront; }
                set { AcrossFront = value; }
            }
            /// <summary>
            /// 乳间距
            /// </summary>
            public string milkInterval
            {
                get { return MilkInterval; }
                set { MilkInterval = value; }
            }
            /// <summary>
            /// 前颈点到乳峰长左
            /// </summary>
            public string neckPointToBbustProminenceLeft
            {
                get { return NeckPointToBbustProminenceLeft; }
                set { NeckPointToBbustProminenceLeft = value; }
            }
            /// <summary>
            /// 前颈点到乳峰长右
            /// </summary>
            public string neckPointToBustProminenceRight
            {
                get { return NeckPointToBustProminenceRight; }
                set { NeckPointToBustProminenceRight = value; }
            }
            /// <summary>
            ///胸围
            /// </summary>
            public string bust
            {
                get { return Bust; }
                set { Bust = value; }
            }
            /// <summary>
            /// 胸腔带围
            /// </summary>
            public string thoracicCavityBand
            {
                get { return ThoracicCavityBand; }
                set { ThoracicCavityBand = value; }
            }
            /// <summary>
            /// 胸下围
            /// </summary>
            public string underBustGirth
            {
                get { return UnderBustGirth; }
                set { UnderBustGirth = value; }
            }
            /// <summary>
            /// 后背宽
            /// </summary>
            public string acrossBack
            {
                get { return AcrossBack; }
                set { AcrossBack = value; }
            }
            /// <summary>
            /// 胸厚
            /// </summary>
            public string chestThickness
            {
                get { return ChestThickness; }
                set { ChestThickness = value; }
            }

        }

        #endregion

        #region 定义腹腰臀部数据--数据结构
        public class cBellyWaistHipDataInfo
        {
            private string ID = "";
            private string Waist = "";
            private string WaistBackLevelDifference = "";
            private string HipThickness = "";
            private string AdominalThickness = "";
            private string HipGirth = "";
            private string ButtockGirth = "";
            private string MaximumHipGirth = "";
            private string Belly = "";
            private string MaximumBellyCircamference = "";
            private string WaistPelvisDistance = "";
            private string WaistPelvisLengthLeft = "";
            private string WaistPelvisLengthRight = "";
            private string WaistUnderarmLeft = "";
            private string WaistUnderarmRight = "";

            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }
            /// <summary>
            /// 腰围
            /// </summary>
            public string waist
            {
                get { return Waist; }
                set { Waist = value; }
            }
            /// <summary>
            /// 腰背水平差
            /// </summary>
            public string waistBackLevelDifference
            {
                get { return WaistBackLevelDifference; }
                set { WaistBackLevelDifference = value; }
            }
            /// <summary>
            /// 臀厚
            /// </summary>
            public string hipThickness
            {
                get { return HipThickness; }
                set { HipThickness = value; }
            }
            /// <summary>
            /// 腹围厚
            /// </summary>
            public string adominalThickness
            {
                get { return AdominalThickness; }
                set { AdominalThickness = value; }
            }
            /// <summary>
            ///上臀围
            /// </summary>
            public string hipGirth
            {
                get { return HipGirth; }
                set { HipGirth = value; }
            }
            /// <summary>
            /// 臀围
            /// </summary>
            public string buttockGirth
            {
                get { return ButtockGirth; }
                set { ButtockGirth = value; }
            }
            /// <summary>
            /// 臀部后突围
            /// </summary>
            public string maximumHipGirth
            {
                get { return MaximumHipGirth; }
                set { MaximumHipGirth = value; }
            }
            /// <summary>
            /// 腹围
            /// </summary>
            public string belly
            {
                get { return Belly; }
                set { Belly = value; }
            }
            /// <summary>
            /// 腹部前突围
            /// </summary>
            public string maximumBellyCircamference
            {
                get { return MaximumBellyCircamference; }
                set { MaximumBellyCircamference = value; }
            }
            /// <summary>
            ///腰臀距后
            /// </summary>
            public string waistPelvisDistance
            {
                get { return WaistPelvisDistance; }
                set { WaistPelvisDistance = value; }
            }
            /// <summary>
            /// 腰臀长左
            /// </summary>
            public string waistPelvisLengthLeft
            {
                get { return WaistPelvisLengthLeft; }
                set { WaistPelvisLengthLeft = value; }
            }
            /// <summary>
            /// 腰臀长右
            /// </summary>
            public string waistPelvisLengthRight
            {
                get { return WaistPelvisLengthRight; }
                set { WaistPelvisLengthRight = value; }
            }
            /// <summary>
            /// 上体侧躯干长左
            /// </summary>
            public string waistUnderarmLeft
            {
                get { return WaistUnderarmLeft; }
                set { WaistUnderarmLeft = value; }
            }
            /// <summary>
            /// 上体侧躯干长右
            /// </summary>
            public string waistUnderarmRight
            {
                get { return WaistUnderarmRight; }
                set { WaistUnderarmRight = value; }
            }
        }

        #endregion

        #region 定义躯干数据--数据结构
        public class cTrunkIntegralDataInfo
        {
            private string ID = "";
            private string BodyHigh = "";
            private string CervicalHeight = "";
            private string CervicalHip = "";
            private string CervicalHeightKnee = "";
            private string CervicalWaist = "";
            private string ScapulaHeight = "";
            private string BreastHeight = "";
            private string NeckFrontHeight = "";


            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }
            /// <summary>
            /// 身高
            /// </summary>
            public string bodyHigh
            {
                get { return BodyHigh; }
                set { BodyHigh = value; }
            }
            /// <summary>
            /// 颈椎点高
            /// </summary>
            public string cervicalHeight
            {
                get { return CervicalHeight; }
                set { CervicalHeight = value; }
            }
            /// <summary>
            /// 颈臀距
            /// </summary>
            public string cervicalHip
            {
                get { return CervicalHip; }
                set { CervicalHip = value; }
            }
            /// <summary>
            /// 颈膝距
            /// </summary>
            public string cervicalHeightKnee
            {
                get { return CervicalHeightKnee; }
                set { CervicalHeightKnee = value; }
            }
            /// <summary>
            ///背长
            /// </summary>
            public string cervicalWaist
            {
                get { return CervicalWaist; }
                set { CervicalWaist = value; }
            }
            /// <summary>
            /// 肩胛骨高
            /// </summary>
            public string scapulaHeight
            {
                get { return ScapulaHeight; }
                set { ScapulaHeight = value; }
            }
            /// <summary>
            /// 胸围高
            /// </summary>
            public string breastHeight
            {
                get { return BreastHeight; }
                set { BreastHeight = value; }
            }
            /// <summary>
            /// 前颈点高
            /// </summary>
            public string neckFrontHeight
            {
                get { return NeckFrontHeight; }
                set { NeckFrontHeight = value; }
            }


        }

        #endregion

        #region 定义上肢数据--数据结构
        public class cUpperLimbsDataInfo
        {
            private string ID = "";
            private string CervicalWristLengthLeft = "";
            private string CervicalWristLengthRight = "";
            private string ArmLengthLeft = "";
            private string ArmLengthRight = "";
            private string UpperArmLengthLeft = "";
            private string UpperArmLengthRight = "";
            private string UpperArmGirthLeft = "";
            private string UpperArmGirthRight = "";
            private string WristGirthLeft = "";
            private string WristGirthRight = "";
            private string HandThickness = "";
            private string HandGirth = "";


            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }
            /// <summary>
            /// 全臂长左
            /// </summary>
            public string cervicalWristLengthLeft
            {
                get { return CervicalWristLengthLeft; }
                set { CervicalWristLengthLeft = value; }
            }
            /// <summary>
            /// 全臂长右
            /// </summary>
            public string cervicalWristLengthRight
            {
                get { return CervicalWristLengthRight; }
                set { CervicalWristLengthRight = value; }
            }
            /// <summary>
            /// 臂长左
            /// </summary>
            public string armLengthLeft
            {
                get { return ArmLengthLeft; }
                set { ArmLengthLeft = value; }
            }
            /// <summary>
            /// 臂长右
            /// </summary>
            public string armLengthRight
            {
                get { return ArmLengthRight; }
                set { ArmLengthRight = value; }
            }
            /// <summary>
            ///上臂长左
            /// </summary>
            public string upperArmLengthLeft
            {
                get { return UpperArmLengthLeft; }
                set { UpperArmLengthLeft = value; }
            }
            /// <summary>
            /// 上臂长右
            /// </summary>
            public string upperArmLengthRight
            {
                get { return UpperArmLengthRight; }
                set { UpperArmLengthRight = value; }
            }
            /// <summary>
            /// 上臂围左
            /// </summary>
            public string upperArmGirthLeft
            {
                get { return UpperArmGirthLeft; }
                set { UpperArmGirthLeft = value; }
            }
            /// <summary>
            /// 上臂围右
            /// </summary>
            public string upperArmGirthRight
            {
                get { return UpperArmGirthRight; }
                set { UpperArmGirthRight = value; }
            }
            /// <summary>
            /// 腕围左
            /// </summary>
            public string wristGirthLeft
            {
                get { return WristGirthLeft; }
                set { WristGirthLeft = value; }
            }
            /// <summary>
            ///腕围右
            /// </summary>
            public string wristGirthRight
            {
                get { return WristGirthRight; }
                set { WristGirthRight = value; }
            }
            /// <summary>
            /// 掌厚
            /// </summary>
            public string handThickness
            {
                get { return HandThickness; }
                set { HandThickness = value; }
            }
            /// <summary>
            /// 掌围
            /// </summary>
            public string handGirth
            {
                get { return HandGirth; }
                set { HandGirth = value; }
            }

        }

        #endregion

        #region 定义下肢数据--数据结构
        public class cLowerLimbsDataInfo
        {
            private string ID = "";
            private string InsideLegLengthLeft = "";
            private string InsideLegLengthRight = "";
            private string SideLengthToWaistLeft = "";
            private string SideLengthToWaistRight = "";
            private string LateralHeightOfWaistLeft = "";
            private string LateralHeightOfWaistRight = "";
            private string ThighGirthLeft = "";
            private string ThighGirthRight = "";
            private string KneeGirthLeft = "";
            private string KneeGirthRight = "";
            private string CalfGirthLeft = "";
            private string CalfGirthRight = "";
            private string AnkleGirthLeft = "";
            private string AnkleGirthRight = "";
            private string WaistKnee = "";
            private string WaistHeight = "";
            private string HipHeight = "";
            private string MaximumHipHeight = "";
            private string CrothHeight = "";
            private string BellyHeight = "";
            private string MaximuBellyHeight = "";
            private string CrothToWaistband = "";
            private string CrothLength = "";


            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }
            /// <summary>
            /// 腿内侧长左
            /// </summary>
            public string insideLegLengthLeft
            {
                get { return InsideLegLengthLeft; }
                set { InsideLegLengthLeft = value; }
            }
            /// <summary>
            /// 腿内侧长右
            /// </summary>
            public string insideLegLengthRight
            {
                get { return InsideLegLengthRight; }
                set { InsideLegLengthRight = value; }
            }
            /// <summary>
            /// 腿外侧长左
            /// </summary>
            public string sideLengthToWaistLeft
            {
                get { return SideLengthToWaistLeft; }
                set { SideLengthToWaistLeft = value; }
            }
            /// <summary>
            /// 腿外侧长右
            /// </summary>
            public string sideLengthToWaistRight
            {
                get { return SideLengthToWaistRight; }
                set { SideLengthToWaistRight = value; }
            }
            /// <summary>
            ///腿外侧缝长左
            /// </summary>
            public string lateralHeightOfWaistLeft
            {
                get { return LateralHeightOfWaistLeft; }
                set { LateralHeightOfWaistLeft = value; }
            }
            /// <summary>
            /// 腿外侧缝长右
            /// </summary>
            public string lateralHeightOfWaistRight
            {
                get { return LateralHeightOfWaistRight; }
                set { LateralHeightOfWaistRight = value; }
            }
            /// <summary>
            /// 大腿围左
            /// </summary>
            public string thighGirthLeft
            {
                get { return ThighGirthLeft; }
                set { ThighGirthLeft = value; }
            }
            /// <summary>
            /// 大腿围右
            /// </summary>
            public string thighGirthRight
            {
                get { return ThighGirthRight; }
                set { ThighGirthRight = value; }
            }
            /// <summary>
            /// 膝围左
            /// </summary>
            public string kneeGirthLeft
            {
                get { return KneeGirthLeft; }
                set { KneeGirthLeft = value; }
            }
            /// <summary>
            ///膝围右
            /// </summary>
            public string kneeGirthRight
            {
                get { return KneeGirthRight; }
                set { KneeGirthRight = value; }
            }
            /// <summary>
            /// 腿肚围左
            /// </summary>
            public string calfGirthLeft
            {
                get { return CalfGirthLeft; }
                set { CalfGirthLeft = value; }
            }
            /// <summary>
            ///腿肚围右
            /// </summary>
            public string calfGirthRight
            {
                get { return CalfGirthRight; }
                set { CalfGirthRight = value; }
            }
            /// <summary>
            /// 踝围左
            /// </summary>
            public string ankleGirthLeft
            {
                get { return AnkleGirthLeft; }
                set { AnkleGirthLeft = value; }
            }
            /// <summary>
            /// 踝围右
            /// </summary>
            public string ankleGirthRight
            {
                get { return AnkleGirthRight; }
                set { AnkleGirthRight = value; }
            }
            /// <summary>
            /// 腰膝距
            /// </summary>
            public string waistKnee
            {
                get { return WaistKnee; }
                set { WaistKnee = value; }
            }
            /// <summary>
            /// 腰高
            /// </summary>
            public string waistHeight
            {
                get { return WaistHeight; }
                set { WaistHeight = value; }
            }
            /// <summary>
            ///臀高
            /// </summary>
            public string hipHeight
            {
                get { return HipHeight; }
                set { HipHeight = value; }
            }
            /// <summary>
            /// 臀后突点高
            /// </summary>
            public string maximumHipHeight
            {
                get { return MaximumHipHeight; }
                set { MaximumHipHeight = value; }
            }
            /// <summary>
            /// 会阴高
            /// </summary>
            public string crothHeight
            {
                get { return CrothHeight; }
                set { CrothHeight = value; }
            }
            /// <summary>
            /// 腹高
            /// </summary>
            public string bellyHeight
            {
                get { return BellyHeight; }
                set { BellyHeight = value; }
            }
            /// <summary>
            ///腹部前突点高
            /// </summary>
            public string maximuBellyHeight
            {
                get { return MaximuBellyHeight; }
                set { MaximuBellyHeight = value; }
            }
            /// <summary>
            ///股上长
            /// </summary>
            public string crothToWaistband
            {
                get { return CrothToWaistband; }
                set { CrothToWaistband = value; }
            }
            /// <summary>
            /// 会阴上部前后长
            /// </summary>
            public string crothLength
            {
                get { return CrothLength; }
                set { CrothLength = value; }
            }

        }

        #endregion

        #region 定义足部数据--数据结构
        public class cFootDataInfo
        {
            private string ID = "";
            private string FootLength = "";
            private string FootWidth = "";
            private string FootGirth = "";
            private string ToeHeihet = "";
            private string FootTarsiHigh = "";
            private string MedialMalleolusHigh = "";
            private string LateralMalleolusHigh = "";

            /// <summary>
            /// 编号
            /// </summary>
            public string id
            {
                get { return ID; }
                set { ID = value; }
            }
            /// <summary>
            /// 足长
            /// </summary>
            public string footLength
            {
                get { return FootLength; }
                set { FootLength = value; }
            }
            /// <summary>
            /// 足宽
            /// </summary>
            public string footWidth
            {
                get { return FootWidth; }
                set { FootWidth = value; }
            }
            /// <summary>
            /// 足围
            /// </summary>
            public string footGirth
            {
                get { return FootGirth; }
                set { FootGirth = value; }
            }
            /// <summary>
            /// 足趾高
            /// </summary>
            public string toeHeihet
            {
                get { return ToeHeihet; }
                set { ToeHeihet = value; }
            }
            /// <summary>
            ///跗骨点高
            /// </summary>
            public string footTarsiHigh
            {
                get { return FootTarsiHigh; }
                set { FootTarsiHigh = value; }
            }
            /// <summary>
            /// 内踝高
            /// </summary>
            public string medialMalleolusHigh
            {
                get { return MedialMalleolusHigh; }
                set { MedialMalleolusHigh = value; }
            }
            /// <summary>
            /// 外踝高
            /// </summary>
            public string lateralMalleolusHigh
            {
                get { return LateralMalleolusHigh; }
                set { LateralMalleolusHigh = value; }
            }

        }

        #endregion

        #region 定义权限－－数据结构
        public class cPopedom
        {
            private int id = 0;
            private string sysuser = "";
            private string password = "";
            Boolean system = false;
            Boolean base_info = false;
            Boolean analyze = false;
            Boolean classify = false;
            Boolean discern = false;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
            {
                get { return id; }
                set { id = value; }
            }
            /// <summary>
            /// 用户名称
            /// </summary>
            public string SysUser
            {
                get { return sysuser; }
                set { sysuser = value; }
            }
            /// <summary>
            /// 用户密码
            /// </summary>
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
         
            /// <summary>
            /// 系统设置权限
            /// </summary>
            public Boolean SystemSet
            {
                get { return system; }
                set { system = value; }
            }
            /// <summary>
            /// 基本信息权限
            /// </summary>
            public Boolean Base_Info
            {
                get { return base_info; }
                set { base_info = value; }
            }
            /// <summary>
            /// 数据分析权限
            /// </summary>
            public Boolean Analyze
            {
                get { return analyze; }
                set { analyze = value; }
            }
           /// <summary>
           /// 体型分类权限
           /// </summary>
           public Boolean Classify
        {
               get { return classify; }
               set { classify = value; }
           }
           /// <summary>
           /// 体型识别权限
           /// </summary>
           public Boolean Discern
        {
               get { return discern; }
               set { discern = value; }
           }
    }

    #endregion

}




