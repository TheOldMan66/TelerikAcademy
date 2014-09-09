<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
    </xsl:text>
    <html>
      <body>
        <h2>Students</h2>
        <ul>
          <xsl:for-each select="students/student">
            <li>
              Name: <xsl:value-of select="name"/>
            </li>
            <li>
              Sex: <xsl:value-of select="sex"/>
            </li>
            <li>
              Birth date: <xsl:value-of select="birthDate"/>
            </li>
            <li>
              Phone: <xsl:value-of select="phone"/>
            </li>
            <li>
              e-mail: <xsl:value-of select="e-mail"/>
            </li>
            <li>
              Course <xsl:value-of select="course"/>
            </li>
            <li>
              Speciality: <xsl:value-of select="speciality"/>
            </li>
            <li>
              Faculty number: <xsl:value-of select="facultyNumber"/>
            </li>
            <li>
              Exams:
              <ul>
                <xsl:for-each select="exam">
                  <li>
                    Name: <xsl:value-of select ="name"/>
                    , Tutor: <xsl:value-of select ="tutor"/>
                    , Score: <xsl:value-of select ="score"/>
                  </li>
                </xsl:for-each>
              </ul>
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
