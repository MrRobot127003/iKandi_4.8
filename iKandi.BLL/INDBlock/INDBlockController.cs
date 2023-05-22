using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;

namespace iKandi.BLL
{
    public class INDBlockController : BaseController
     {
        #region

        public INDBlockController()
        {
        }

        public INDBlockController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<INDBlock> GetAllBlocks(int PageSize, int PageIndex, out int TotalPageCount, int ClientId, string SearchText)
        {
            return this.INDBlockDataProviderInstance.GetAllBlocks(PageSize, PageIndex, out TotalPageCount, ClientId, SearchText);
        }

        public INDBlock Save(INDBlock Block)
        {

            if (Block.BlockID == -1)
            {
                this.INDBlockDataProviderInstance.InsertIndBlock(Block);
            }
            else
            {
                this.INDBlockDataProviderInstance.UpdateIndBlock(Block);
            }

            return Block;
        }

        public INDBlock GetBlockById(int BlockId)
        {
            return this.INDBlockDataProviderInstance.GetBlockById(BlockId);
        }

        public string GetNewBlockNumber()
        {
            return this.INDBlockDataProviderInstance.GetNewBlockNumber();
        }

        public INDBlock GetBlockByBlockNumber(string BlockNumber)
        {
            return this.INDBlockDataProviderInstance.GetBlockByBlockNumber(BlockNumber);
        }

      
     }
}

