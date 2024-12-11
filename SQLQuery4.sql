SELECT 
    Courses.Title, 
    COUNT(Enrollments.EnrollmentId) AS TotalEnrollments
FROM 
    Courses
LEFT JOIN 
    Enrollments ON Courses.CourseId = Enrollments.CourseId
GROUP BY 
    Courses.Title;
