### Subversion(SVN) 용어 및 사용법

\- 체크아웃 : 저장소에 접근해 소스 코드와 버전관리를 위한 파일들을 받아 오는 행위

\- 추가 : 말 그대로 파일을 서버에 올린다

\- 커밋 : 내가 수정한 코드를 올린다

\- 업데이트 : 최신 리버전된 버전의 코드를 받는다

---

**용어 설명**
저장소 : 리포지토리(Repository)라고도 하며 모든 프로젝트의 프로그램 소스들은 이 저장소 안에 저장이 됩니다. 그리고 소스뿐만이 아니라 소스의 변경 사항도 모두 저장됩니다. 네트워크를 통해서 여러 사람이 접근 할 수 있습니다. 버전 관리 시스템 마다 각각 다른 파일 시스템을 가지고 있으며 Subversion은 Berkeley DB를 사용합니다. 한 프로젝트 마다 하나의 저장소가 필요합니다.

리비전(Revision) : 소스 파일등을 수정하여 커밋하게 되면 일정한 규칙에 의해 숫자가 증가 합니다. 저장소에 저장된 각각의 파일 버전이라 할 수 있습니다. Subversion의 경우 파일별로 리비전이 매겨지지 않고 한번 커밋 한 것으로 전체 리비전이 매겨 집니다. 리비전을 보고 프로젝트 진행 상황을 알 수 있습니다.

trunk : 단어 자체의 뜻은 본체 부분, 나무줄기, 몸통 등 입니다. 프로젝트에서 가장 중심이 되는 디렉토리입니다. 모든 프로그램 개발 작업은 trunk 디렉토리에서 이루어집니다. 그래서 위의 구조에서 trunk 디렉토리 아래에는 바로 소스들의 파일과 디렉토리가 들어가게 됩니다.

branches : 나무줄기(trunk)에서 뻗어져 나온 나무 가지를 뜻합니다. trunk 디렉토리에서 프로그램을 개발하다 보면 큰 프로젝트에서 또 다른 작은 분류로 빼서 따로 개발해야 할 경우가 생깁니다. 프로젝트안의 작은 프로젝트라고 생각하면 됩니다. branches 디렉토리 안에 또 다른 디렉토리를 두어 그 안에서 개발하게 됩니다.

tags : tag는 꼬리표라는 뜻을 가지고 있습니다. 이 디렉토리는 프로그램을 개발하면서 정기적으로 릴리즈를 할 때 0.1, 0.2, 1.0 하는 식으로 버전을 붙여 발표하게 되는데 그때그때 발표한 소스를 따로 저장하는 공간입니다. 위에서 보면 tags 디렉토리 아래에는 버전명으로 디렉토리가 만들어져 있습니다.

**명령어 의미**
Import : svn import sampledir svn+ssh://svn-domain/svn/sample/trunk
맨 처음 프로젝트 시작할때 저장소에 등록하는 명령어 한 번 하고 나면 쓸일이 잘 없을 듯.

Checkout : svn checkout svn+ssh://svn-domain/svn/sample/trunk sample
저장소에서 소스를 받아 오는 명령어. 받아온 소스에는 소스 뿐만이 아니라 버젼관리를 위한 파일도 같이 받아 온다. 지우거나 변경시 저장소와 연결 불가능

Export : svn export svn+ssh://svn-domain/svn/sample2/trunk sample
체크아웃과는 달리 버젼관리 파일을 뺀 순수한 소스만 가져오는 명령어 마지막에 사용.

Commit : svn commit
체크아웃 한 소스를 수정, 파일 추가, 삭제 등을 한 뒤 저장소에 저장하여 갱신 하는 명령어. Revision이 1 증가 한다.

Update : svn update
체크아웃 해서 받은 소스를 최신의 소스로 업데이트 하는 명령어. 소스 수정이나 Commit 하기전에 한 번씩 해줘야 할 듯. 잘 못하면 소스 망치는 경우가 있을 듯.

Log : svn log
저장소에 어떠한 것들이 변경 되었는지 확인 할 수 있는 log 명령어

Diff : svn diff --revision 4 sample.c
diff 명령은 예전 소스 파일과 지금의 소스 파일을 비교해 보는 명령어

Blame : svn blame sample.c
Blame은 한 소스파일을 대상으로 각 리비전 대해서 어떤 행을 누가 수정했는지 알아보기 위한 명령어

lock : svn lock hello.c
파일에 락을 걸어 락을 건 사용자만이 수정할 수 있게 해주는 명령어. 해제는 svn unlock.
왜 파일에 락을 걸었는지 로그를 기록 할 수 있다.

Add : svn add hello.c
새 파일을 만들었을 경우에 파일을 추가 해주는 명령어. 그 뒤엔 꼭 svn commit를 꼭 해줘야 한다.
새 파일을 생성해서 올릴 때에도 꼭 add를 해줘야 함. 안해주면 commit을 해도 안 올라감.

파일 백업및 복구
dump : svnadmin dump sample > sample.dump
load : svnadmin load sample < sample.dump
새 파일을 만들었을 경우 
\1. svn add filename.* 
\2. svn ci filename.*

그냥 기존 소스 수정할 경우 
\1. svn ci filename.* 

항상 svn update는 꼭 해주자

svn status : 자신이 수정하고 있는 파일의 상태를 알려주는 명령어  

출처 : http://blog.naver.com/PostView.nhn?blogId=nkw68&logNo=121858787





