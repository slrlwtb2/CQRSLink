
# 🚀 CQRSLink

**CQRSLink** คือไลบรารี .NET สำหรับการใช้งานแนวคิด **CQRS (Command/Query Responsibility Segregation)** แบบเบาๆ ที่ออกแบบมาให้เรียบง่ายและใช้งานสะดวก โดยไม่ต้องพึ่งพาไลบรารีอย่าง MediatR

> เพราะว่า MediatR รุ่นใหม่เหมือนว่าจะต้องเสียเงินแล้ว เราเลยขอทำเวอร์ชันฟรีใช้เองไปเลย! 😎

---

## ✅ คุณสมบัติ

- รองรับแนวทาง CQRS (Command และ Query แยกจากกัน)
- ใช้งานง่ายผ่าน interface เช่น `ICommandHandler` และ `IQueryHandler`
- รองรับ Dependency Injection
- เหมาะสำหรับใช้เป็น Submodule หรือ Library ในหลายโปรเจกต์

---

## 📦 โครงสร้างพื้นฐาน

```bash
RelayCQRS/
├── Interfaces/           # Interfaces หลักของระบบ CQRS
├── Mediator/             # ตัวจัดการส่ง Command / Query
├── Extensions/           # ServiceCollection Extension สำหรับ DI
└── RelayCQRS.csproj
