# RemoteAutoBuild (원격 자동 빌드)

RemoteAutoBuild는 다양한 마이크로서비스의 빌드 프로세스를 자동화하는 .NET 기반 웹 서비스입니다. 이 서비스는 클라이언트가 다양한 제품에 대한 빌드를 트리거하고 버전 정보를 검색할 수 있는 RESTful API를 제공합니다.

## 기능

- 다양한 마이크로서비스에 대한 원격 빌드 트리거링
- 다양한 제품 카테고리 지원 (delivery_msa, kuke_board_msa, loans_msa)
- 조직 기반 분류
- 버전 정보 검색
- API 문서화 및 테스트를 위한 Swagger UI
- 교차 출처 리소스 공유(CORS) 지원

## 요구 사항

- .NET 8.0 SDK
- Python (빌드 스크립트 실행용)
- Windows, macOS 또는 Linux 운영 체제

## 설치

1. 저장소 복제:
   ```
   git clone https://github.com/yourusername/RemoteAutoBuild.git
   cd RemoteAutoBuild
   ```

2. 프로젝트 빌드:
   ```
   dotnet build
   ```

3. 애플리케이션 실행:
   ```
   dotnet run --project AutoBuild
   ```

서비스는 기본적으로 `https://0.0.0.0:5159`에서 시작됩니다.

## 사용법

### API 엔드포인트

#### 1. 빌드 트리거

```http
POST /ProductInfo/run-file
Content-Type: application/json

{
  "Path": "path/to/build/directory",
  "OrganName": "IT",
  "ProductName": "delivery_msa"
}
```

**매개변수:**
- `Path`: 빌드를 위한 파일 경로
- `OrganName`: 조직 카테고리 (None, HumanResources, Finance, IT, Marketing, RnD, Operations)
- `ProductName`: 제품 카테고리 (None, delivery_msa, kuke_board_msa, loans_msa)

**응답:**
```
delivery_msa 빌드가 완료 되었습니다
```

#### 2. 버전 정보 가져오기

```http
GET /api/VersionInfo
```

**응답:**
```json
[
  "10.0.0.1",
  "987654321"
]
```

### Swagger UI 사용

개발 모드에서 실행할 때 다음 주소에서 Swagger UI에 액세스할 수 있습니다:
```
https://localhost:5159/swagger
```

이는 API 엔드포인트를 탐색하고 테스트할 수 있는 대화형 인터페이스를 제공합니다.

## 클라이언트 애플리케이션

이 서비스를 위한 클라이언트 애플리케이션은 다음에서 사용할 수 있습니다:
```
https://github.com/songminkyu/AutoBuilderlauncher
```

## 프로젝트 구조

- **Controllers/**
  - `ProductInfoController.cs`: 다양한 제품에 대한 빌드 요청 처리
  - `VersionInfoController.cs`: 버전 정보 제공

- **Models/**
  - `ProductInfo.cs`: 제품 빌드 요청을 위한 데이터 모델
  - `VersionInfo.cs`: 버전 정보를 위한 데이터 모델

- **Enums/**
  - `ProductCategory.cs`: 지원되는 제품 유형 정의
  - `OrganCategory.cs`: 조직 카테고리 정의

## 기여하기

1. 저장소 포크
2. 기능 브랜치 생성 (`git checkout -b feature/amazing-feature`)
3. 변경 사항 커밋 (`git commit -m 'Add some amazing feature'`)
4. 브랜치에 푸시 (`git push origin feature/amazing-feature`)
5. Pull Request 열기

## 라이선스

이 프로젝트는 MIT 라이선스에 따라 라이선스가 부여됩니다 - 자세한 내용은 LICENSE 파일을 참조하세요.
