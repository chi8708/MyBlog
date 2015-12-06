using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    /// <summary>
    ///     可持久到数据库的领域模型的基类。
    /// </summary>
    [Serializable]
    public abstract class EntityBase
    {

        /// <summary>
        ///     数据实体基类
        /// </summary>
        protected EntityBase()
        {
            IsDeleted = false;
            Id = Guid.NewGuid().ToString("N");
        }

        #region 属性

        [Key]
        public virtual string Id{ get; set; }

        /// <summary>
        /// 逻辑上的删除，非物理删除
        /// </summary>
        public bool IsDeleted { get; set; }

        #endregion
    }
}
