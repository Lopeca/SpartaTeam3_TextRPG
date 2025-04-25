using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 선택지의 다양한 유형을 구상하고 만들었습니다
// 메뉴에 Action을 넣어 그걸 일단 다 해내고 있어서 지금은 인터페이스에 큰 의미는 없습니다
 public interface ISelectable
 {
    public string Name { get; }
    public void ActBySelect();
 }
